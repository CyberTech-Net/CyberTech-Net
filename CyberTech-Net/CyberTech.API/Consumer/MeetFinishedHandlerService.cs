using CyberTech.Core.Dto.MatchResult;
using CyberTech.Core.IServices;
using CyberTech.MessagesContracts.TournamentMeets;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using MatchEndedQueueSettings = CyberTech.Settings.RabbitMqQueueSettings.MatchEnded;

namespace CyberTech.API.HostedServices
{
    public class MeetFinishedHandlerService(IHostApplicationLifetime lifetime, IServiceProvider services, IOptions<MatchEndedQueueSettings> matchEndedQueueSettings) : BackgroundService
    {
        private readonly IHostApplicationLifetime _lifetime = lifetime;
        private readonly IServiceProvider _services = services;
        private readonly MatchEndedQueueSettings _matchEndedQueueSettings = matchEndedQueueSettings.Value;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (!await WaitForAppStartup(_lifetime, stoppingToken))
                return;

            using var scope = _services.CreateScope();
            var mqConnection = scope.ServiceProvider.GetRequiredService<IConnection>();
            var matchResultsService = scope.ServiceProvider.GetRequiredService<IMatchResultsService>();
            var channel = mqConnection.CreateModel();
            _ = Task.Run(() => MatchEndedConsumer.Register(channel, _matchEndedQueueSettings, matchResultsService), stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {

            }
        }
        static async Task<bool> WaitForAppStartup(IHostApplicationLifetime lifetime, CancellationToken token)
        {
            // Создаём TaskCompletionSource для ApplicationStarted
            var startedSource = new TaskCompletionSource();
            using var reg1 = lifetime.ApplicationStarted.Register(() => startedSource.SetResult());

            // Создаём TaskCompletionSource для stoppingToken
            var cancelledSource = new TaskCompletionSource();
            using var reg2 = token.Register(() => cancelledSource.SetResult());

            // Ожидаем любое из событий запуска или запроса на остановку
            Task completedTask = await Task.WhenAny(startedSource.Task, cancelledSource.Task).ConfigureAwait(true);

            // Если завершилась задача ApplicationStarted, возвращаем true, иначе false
            return completedTask == startedSource.Task;
        }

    }

    internal static class MatchEndedConsumer
    {
        public static void Register(IModel channel, MatchEndedQueueSettings queueSettings, IMatchResultsService matchResultsService)
        {
            channel.ExchangeDeclare(queueSettings.ExchangeName, queueSettings.Type, queueSettings.Durable, queueSettings.AutoDelete, null);
            channel.BasicQos(0, 1, false);
            channel.QueueDeclare(queueSettings.QueueName, queueSettings.Durable, false, queueSettings.AutoDelete, null);
            channel.QueueBind(queueSettings.QueueName, queueSettings.ExchangeName, queueSettings.RoutingKey, null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (sender, e) =>
            {
                var body = Encoding.UTF8.GetString(e.Body.ToArray());
                var message = JsonSerializer.Deserialize<MatchEnded>(body);
                channel.BasicAck(e.DeliveryTag, false);
                await matchResultsService.CreateAsync(new CreatingResultDto(
                    matchId: message.MatchId,
                    teamId: message.TeamId,
                    score: message.Score,
                    isWin: message.IsWin));
            };

            channel.BasicConsume(queueSettings.QueueName, false, consumer);
            Console.WriteLine($"Subscribed to the queue {queueSettings.QueueName} with key {queueSettings.RoutingKey} (exchange name: {queueSettings.ExchangeName})");
        }
    }
}

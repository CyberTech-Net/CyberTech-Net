using CyberTech.Core.IServices;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace CyberTech.Application.Services
{
    public class RabbitMqService(IConnection connection, IOptions<Settings.RabbitMqQueueSettings.MatchPlanned> queueSettings) : IRabbitMqService
    {
        private readonly IConnection _connection = connection;
        private readonly Settings.RabbitMqQueueSettings.MatchPlanned _queueSettings = queueSettings.Value;

        public void SendMessage(object obj)
        {
            var message = JsonSerializer.Serialize(obj);
            SendMessage(message);
        }

        public void SendMessage(string message)
        {
            using var channel = _connection.CreateModel();
            channel.ExchangeDeclare(_queueSettings.ExchangeName, _queueSettings.ExchangeType, _queueSettings.Durable);

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
            channel.BasicPublish(exchange: _queueSettings.ExchangeName,
                routingKey: _queueSettings.RoutingKey,
                basicProperties: null,
                body: body);

            channel.Close();
        }
    }
}

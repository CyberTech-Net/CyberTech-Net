using Cybertech.MatchApi.Services;
using CyberTech.MessagesContracts.TournamentMeets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using StackExchange.Redis;

namespace Cybertech.MatchApi.HostedService
{
    public class GetRedisDataService : BackgroundService
    {
        private readonly IConnectionMultiplexer _redisCache;
        private readonly ICheckMatchService _checkMatchService;
        private readonly ILogger<GetRedisDataService> _logger;
        private readonly IConfiguration _configuration;

        public GetRedisDataService(IConnectionMultiplexer redisCache, ICheckMatchService checkMatchService,
            ILogger<GetRedisDataService> logger)
        {
            _redisCache = redisCache;
            _checkMatchService = checkMatchService;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("{data} Service for scan Redis data is starting", DateTime.UtcNow);
            stoppingToken.Register(() => _logger.LogInformation("{data} Service for scan Redis data has stopped", DateTime.UtcNow));
            while (!stoppingToken.IsCancellationRequested)
            {
                foreach (var endpoint in _redisCache.GetEndPoints())
                {
                    var keys = _redisCache.GetServer(endpoint).Keys();                                        
                    foreach (var key in keys)
                    {
                        var ss = _redisCache.GetDatabase().StringGet(key);
                        var basketJson = JsonSerializer.Deserialize<MatchPlanned>(ss);

                        // Удаляем запись из Redis
                        _redisCache.GetDatabase().KeyDeleteAsync(key);
                        _logger.LogInformation("{data} Received MatchPlanned from Redis with Id={id}", DateTime.UtcNow, basketJson.Id);
                        // Вызываем сервис проверки матча
                        _checkMatchService.CheckMatchAsync(basketJson.Id, basketJson.StartDateTime);
                    }
                }
                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
            _logger.LogInformation("{data} Service for scan Redis data has stopped", DateTime.UtcNow);
        }
    }
}

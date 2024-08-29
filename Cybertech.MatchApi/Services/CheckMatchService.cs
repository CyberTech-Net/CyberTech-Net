using MassTransit;
using Microsoft.Extensions.Logging;
using CyberTech.MessagesContracts.Matches;
using CyberTech.MessagesContracts.TournamentMeets;
using StackExchange.Redis;
using System.Text.Json;

namespace Cybertech.MatchApi.Services
{
    public class CheckMatchService : ICheckMatchService
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<CheckMatchService> _logger;
        private readonly IConnectionMultiplexer _redisCache;

        public CheckMatchService(ILogger<CheckMatchService> logger, IPublishEndpoint publishEndpoint,
            IConnectionMultiplexer redisCache)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
            _redisCache = redisCache;
        }

        public async Task CheckMatchAsync(Guid MatchId, DateTime dt)
        {
            if (dt.ToUniversalTime()<= DateTime.Now.ToUniversalTime())
            {
                _logger.LogInformation("{data} Publish MatchForGenResult with Id={id}", DateTime.UtcNow, MatchId);
                await _publishEndpoint.Publish(new MatchForGenResult
                {
                    MatchId = MatchId                    
                });
            }
            else
            // Пишем в Redis.
            {
                _logger.LogInformation("{data} Send data to Redis with Id={id}", DateTime.UtcNow, MatchId);
                var redisMessage = new MatchPlanned
                {
                    Id = MatchId,
                    StartDateTime = dt
                };
                string basketJson = JsonSerializer.Serialize(redisMessage);
                var db = _redisCache.GetDatabase();
                await db.StringSetAsync(redisMessage.Id.ToString(), basketJson);
            }
        }
    }
}

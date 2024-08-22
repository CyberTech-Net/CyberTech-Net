using Cybertech.MatchApi.Services;
using CyberTech.MessagesContracts.TournamentMeets;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Cybertech.MatchApi.Consumer
{
    public class CheckMatchData : IConsumer<MatchPlanned>
    {
        private readonly ILogger<CheckMatchData> _logger;
        private readonly ICheckMatchService _checkMatchService;


        public CheckMatchData(ILogger<CheckMatchData> logger, ICheckMatchService checkMatchService)
        {
            _logger = logger;
            _checkMatchService = checkMatchService;
        }

        public Task Consume(ConsumeContext<MatchPlanned> context)
        {
            var message = context.Message;
            if (message != null)
            {                
                _logger.LogInformation("{data} Received MatchPlanned with Id={id}", DateTime.UtcNow, message.Id);
                _checkMatchService.CheckMatchAsync(message.Id, message.StartDateTime);
            }
            return Task.CompletedTask;
        }
    }
}


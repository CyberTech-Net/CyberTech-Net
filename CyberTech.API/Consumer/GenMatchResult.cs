using CyberTech.Application.Services;
using CyberTech.MessagesContracts.Matches;
using MassTransit;

namespace CyberTech.API.Consumer
{
    public class GenMatchResult : IConsumer<MatchForGenResult>
    {        
        private readonly ILogger<GenMatchResult> _logger;
        private readonly IGenMatchResultService _genMatchResultService;

        public GenMatchResult(ILogger<GenMatchResult> logger, IGenMatchResultService genMatchResultService)
        {            
            _logger = logger;
            _genMatchResultService = genMatchResultService;
        }

        public Task Consume(ConsumeContext<MatchForGenResult> context)
        {
            var message = context.Message;
            if (message != null)
            {
                _logger.LogInformation("{data} Received MatchForGenResult with Id={id}", DateTime.UtcNow, message.MatchId);
                // Запускаем сервис генерации с записью в БД.
                _genMatchResultService.CreateMatchResultAsync(message.MatchId);
            }
            return Task.CompletedTask;
        }
    }
}

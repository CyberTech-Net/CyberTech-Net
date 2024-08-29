using CyberTech.Core.Dto.MatchResult;
using CyberTech.Core.IServices;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CyberTech.Application.Services
{
    public class GenMatchResultService : IGenMatchResultService
    {
        private readonly IMatchResultService _matchResultService;
        private readonly IMatchService _matchService;
        private readonly Random rand = new();
        private readonly ILogger<GenMatchResultService> _logger;

        public GenMatchResultService(IMatchResultService matchResultService, IMatchService matchService, 
            ILogger<GenMatchResultService> logger)
        {
            _matchResultService = matchResultService;
            _matchService = matchService;
            _logger = logger;
        }

        public async Task CreateMatchResultAsync(Guid MatchId)
        {
            // Получаем запись из Match
            var match = _matchService.GetByIdAsync(MatchId, CancellationToken.None).Result ?? throw new Exception($"Запись с идентфикатором {MatchId} не найдена");

            Guid firstTeamId = match.FirstTeam.Id;
            Guid secondtTeamId = match.SecondTeam.Id;
            int score1 = rand.Next(0, 100);
            int score2 = rand.Next(0, 100);
            var firstResult = new CreatingMatchResultDto
            {
                TeamId = firstTeamId,
                MatchId = MatchId,
                Score = score1,
                IsWin = score1 > score2
            };
            var secondResult = new CreatingMatchResultDto
            {
                TeamId = secondtTeamId,
                MatchId = MatchId,
                Score = score2,
                IsWin = score2 >= score1
            };
            _logger.LogInformation("{data} Generation result complete for match with Id={id}", DateTime.UtcNow, MatchId);
            await _matchResultService.CreateResultAsync(firstResult, secondResult);
        }
    }
}

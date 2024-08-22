using CyberTech.Core.Dto.MatchResult;
using CyberTech.Core.IServices;
using Microsoft.Extensions.Logging;

namespace CyberTech.Application.Services
{
    public class GenMatchResultService : IGenMatchResultService
    {
        private readonly IMatchResultService _matchResultService;
        private readonly IMatchService _matchtService;
        private static Random rand = new();
        private readonly ILogger<GenMatchResultService> _logger;

        public GenMatchResultService(IMatchResultService matchResultService, IMatchService matchtService, 
            ILogger<GenMatchResultService> logger)
        {
            _matchResultService = matchResultService;
            _matchtService = matchtService;
            _logger = logger;
        }

        public async Task CreateMatchResultAsync(Guid MatchId)
        {
            // Получаем запись из Match
            var match = _matchtService.GetByIdAsync(MatchId, CancellationToken.None).Result ?? throw new Exception($"Запись с идентфикатором {MatchId} не найдена");

            Guid firstTeamId = match.FirstTeam.Id;
            Guid secondtTeamId = match.SecondTeam.Id;
            int score1 = rand.Next(0, 100);
            int score2 = rand.Next(0, 100);
            CreatingMatchResultDto firstResult = new CreatingMatchResultDto
            {
                TeamId = firstTeamId,
                MatchId = MatchId,
                Score = score1,
                IsWin = score1 > score2
            };
            CreatingMatchResultDto secondResult = new CreatingMatchResultDto
            {
                TeamId = secondtTeamId,
                MatchId = MatchId,
                Score = score2,
                IsWin = score1 > score2
            };
            await _matchResultService.CreateAsync(firstResult);
            _logger.LogInformation("{data} Generation result complete for team with Id={id}", DateTime.UtcNow, firstTeamId);
            await _matchResultService.CreateAsync(secondResult);
            _logger.LogInformation("{data} Generation result complete for team with Id={id}", DateTime.UtcNow, secondtTeamId);
        }
    }
}

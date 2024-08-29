using CyberTech.Core.Dto.TeamRating;
using CyberTech.Core.IRepositories;
using CyberTech.Core.IServices;

namespace CyberTech.Application.Services
{
    public class TeamRatingService : ITeamRatingService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly IMatchResultRepository _matchResultRepository;

        public TeamRatingService(ITeamRepository teamRepository, IMatchRepository matchRepository, IMatchResultRepository matchResultRepository)
        {
            _teamRepository = teamRepository;
            _matchRepository = matchRepository;
            _matchResultRepository = matchResultRepository;
        }

        public async Task<ICollection<TeamRatingDto>> GetTeamRating()
        {
            var teams = await _teamRepository.GetAllAsync(CancellationToken.None);
            var matches = await _matchRepository.GetAllAsync(CancellationToken.None);
            var matchResults = await _matchResultRepository.GetAllAsync(CancellationToken.None);
            var result = new List<TeamRatingDto>();
            foreach (var team in teams)
            {
                var tempMatch = matches.Where(x => x.FirstTeamId == team.Id || x.SecondTeamId == team.Id).ToList();
                var tempMatchResult = matchResults.Where(x => x.TeamId == team.Id).ToList();
                var tempMatchDataFuture = tempMatch.
                        Where(x => x.StartDateTime.ToUniversalTime() > DateTime.Now.ToUniversalTime()).
                        OrderBy(x => x.StartDateTime.ToUniversalTime()).
                        FirstOrDefault();
                var tempMatchDataLast = tempMatch.
                        Where(x => x.StartDateTime.ToUniversalTime() <= DateTime.Now.ToUniversalTime()).
                        OrderBy(x => x.StartDateTime.ToUniversalTime()).
                        FirstOrDefault();
                result.Add(new TeamRatingDto
                {
                    Id = team.Id,
                    TeamNaim = team.TitleTeam,
                    Score = tempMatchResult.Sum(x => x.Score),
                    WinCount = tempMatchResult.Where(x => x.IsWin).Count(),
                    LoseCount = tempMatchResult.Where(x => !x.IsWin).Count(),
                    MatchCount = tempMatchResult.Count(),
                    FutureMatch = tempMatchDataFuture != null ? tempMatchDataFuture.StartDateTime : null,
                    LastMatch = tempMatchDataLast != null ? tempMatchDataLast.StartDateTime : null,
                    ImageId = team.ImageId
                });
            }
            return result.OrderByDescending(x => x.Score).ToList();
        }
    }
}

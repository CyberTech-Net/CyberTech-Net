using AutoMapper;
using CyberTech.Core.Dto.MatchCard;
using CyberTech.Core.Dto.Team;
using CyberTech.Core.Dto.Tournament;
using CyberTech.Core.IRepositories;
using CyberTech.Core.IServices;
using CyberTech.Domain.Models.Handbooks;
using CyberTech.Domain.Models.Tournaments;
using System.Threading;

namespace CyberTech.Application.Services
{
    public class MatchCardService : IMatchCardService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly IMatchResultRepository _matchResultRepository;
        private readonly IMapper _mapper;

        public MatchCardService(ITeamRepository teamRepository, IMatchRepository matchRepository, IMatchResultRepository matchResultRepository,
            IMapper mapper)
        {
            _teamRepository = teamRepository;
            _matchRepository = matchRepository;
            _matchResultRepository = matchResultRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<MatchCardDto>> GetMatchCard(CancellationToken cancellationToken)
        {
            var teams = await _teamRepository.GetAllAsync(CancellationToken.None);
            var matches = await _matchRepository.GetAllAsync(CancellationToken.None);
            var matchResults = await _matchResultRepository.GetAllAsync(CancellationToken.None);
            var result = new List<MatchCardDto>();
            foreach (var match in matches)
            {
                var tempMatchResultFirstTeam = matchResults.Where(x => x.TeamId == match.FirstTeam.Id && x.MatchId == match.Id).FirstOrDefault();
                var tempMatchResultSecondTeam = matchResults.Where(x => x.TeamId == match.SecondTeam.Id && x.MatchId == match.Id).FirstOrDefault();
                result.Add(new MatchCardDto
                {
                    Id = match.Id,
                    FirstTeam = _mapper.Map<TeamEntity, TeamDto>(match.FirstTeam),
                    SecondTeam = _mapper.Map<TeamEntity, TeamDto>(match.SecondTeam),
                    FirstTeamResult = tempMatchResultFirstTeam != null ? (tempMatchResultFirstTeam.IsWin ? "Win" : "Lose") : "",
                    SecondTeamResult = tempMatchResultSecondTeam != null ? (tempMatchResultSecondTeam.IsWin ? "Win" : "Lose") : "",
                    FirstTeamScore = tempMatchResultFirstTeam != null ? (tempMatchResultFirstTeam.Score) : 0,
                    SecondTeamScore = tempMatchResultSecondTeam != null ? (tempMatchResultSecondTeam.Score) : 0,
                    Tournament = _mapper.Map<TournamentEntity, TournamentDto>(match.Tournament),
                    StartDateTime = match.StartDateTime
                });
            }
            return result.OrderByDescending(x => x.StartDateTime).ToList();
        }
    }
}

using CyberTech.Core.Dto.Match;
using CyberTech.Domain.Models.Tournaments;

namespace CyberTech.Core.Mapping
{
    public static class MatchMapper
    {
        public static Match ConvertToBaseModel(CreatingMatchDto dto)
        {
            return Match.CreateNewInstanse(
                tournamentId: dto.TournamentId, 
                startDateTime: dto.StartDateTime, 
                firtstTeamId: dto.FirtstTeamId, 
                secondTeamId: dto.SecondTeamId);
        }

        public static MatchDto ConvertToDto(Match dbEntity)
        {
            return new MatchDto(
                id: dbEntity.Id,
                startDateTime: dbEntity.StartDateTime,
                tournamentId: dbEntity.TournamentId);
        }

        public static List<MatchDto> ConvertToDto(List<Match> dbEntities) => dbEntities.Select(ConvertToDto).ToList();
    }
}

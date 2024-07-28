using CyberTech.Core.Dto.MatchResult;
using CyberTech.Domain.Models.Tournaments;

namespace CyberTech.Core.Mapping
{
    public class MatchResultMapper
    {
        public static MatchResult ConvertToBaseModel(CreatingResultDto dto)
        {
            return MatchResult.CreateNewInstanse(
                matchId: dto.MatchId, 
                teamId: dto.TeamId, 
                score: dto.Score, 
                isWin: dto.IsWin);
        }

        public static ResultDto ConvertToDto(MatchResult dbEntity)
        {
            return new ResultDto(
                id: dbEntity.Id,
                match: MatchMapper.ConvertToDto(dbEntity.Match),
                team: TeamMapper.ConvertToDto(dbEntity.Team),
                score: dbEntity.Score,
                isWin: dbEntity.IsWin);
        }

        public static List<ResultDto> ConvertToDto(List<MatchResult> dbEntities) => dbEntities.Select(ConvertToDto).ToList();
    }
}

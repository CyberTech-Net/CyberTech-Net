using CyberTech.API.ModelViews.MatchResult;
using CyberTech.Core.Dto.MatchResult;

namespace CyberTech.API.Mapping
{
    public static class MatchResultMapper
    {
        public static CreatingResultDto ConvertToDto(CreatingResultModel modelApi)
        {
            return new CreatingResultDto(
                matchId: modelApi.MatchId, 
                teamId: modelApi.TeamId, 
                score: modelApi.Score, 
                isWin: modelApi.IsWin);
        }

        public static UpdatingResultDto ConvertToDto(UpdatingResultModel modelApi)
        {
            return new UpdatingResultDto(
                id: modelApi.Id, 
                score: modelApi.Score, 
                isWin: modelApi.IsWin);
        }

        public static ResultModel ConvertToModelApi(ResultDto dto)
        {
            return new ResultModel(
                id: dto.Id,
                match: MatchMapper.ConvertToModelApi(dto.Match),
                team: null,
                score: dto.Score,
                isWin: dto.IsWin);
        }

        public static List<ResultModel> ConvertToModelApi(List<ResultDto> dtos) => dtos.Select(ConvertToModelApi).ToList();
    }
}

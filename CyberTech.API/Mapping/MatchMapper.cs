using CyberTech.API.ModelViews.Match;
using CyberTech.Core.Dto.Match;

namespace CyberTech.API.Mapping
{
    public static class MatchMapper 
    {
        public static CreatingMatchDto ConvertToDto(CreatingMatchModel modelApi) 
        {
            return new CreatingMatchDto(
                tournamentId: modelApi.TournamentId,
                startDateTime: modelApi.StartDateTime,
                firtstTeamId: modelApi.FirtstTeamId,
                secondTeamId: modelApi.SecondTeamId) ; 
        }

        public static MatchModel ConvertToModelApi(MatchDto modelApi)
        {
            return new MatchModel(
                id: modelApi.Id,
                tournamentId: modelApi.TournamentId,
                startDateTime: modelApi.StartDateTime);
        }
        public static List<MatchModel> ConvertToModelApi(List<MatchDto> modelsApi) => modelsApi.Select(ConvertToModelApi).ToList();

        public static UpdatingMatchDto ConvertToDto(UpdatingMatchModel modelApi)
        {
            return new UpdatingMatchDto(
                tournamentId: modelApi.TournamentId,
                startDateTime: modelApi.StartDateTime);
        }
    }
}

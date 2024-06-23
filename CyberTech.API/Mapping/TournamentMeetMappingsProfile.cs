using AutoMapper;
using CyberTech.API.ModelViews.TournamentMeet;
using CyberTech.Core.Dto.TournamentMeet;

namespace CyberTech.API.Mapping
{
    public class TournamentMeetMappingsProfile : Profile
    {
        public TournamentMeetMappingsProfile()
        {
            CreateMap<TournamentMeetDto, TournamentMeetModel>()
                .ForMember(d => d.DataTournamentMeet, map => map.MapFrom(m => m.DataTournamentMeet.ToShortDateString()))
                .ForMember(d => d.Tournament, map => map.MapFrom(m => m.Tournament))
                .ForMember(d => d.TournamentId, map => map.MapFrom(m => m.TournamentId));
            CreateMap<CreatingTournamentMeetModel, CreatingTournamentMeetDto>();
            CreateMap<UpdatingTournamentMeetModel, UpdatingTournamentMeetDto>();
        }
    }
}

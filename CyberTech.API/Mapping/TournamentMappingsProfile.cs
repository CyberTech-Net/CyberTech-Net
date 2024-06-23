using AutoMapper;
using CyberTech.API.ModelViews.Tournament;
using CyberTech.Core.Dto.Tournament;

namespace CyberTech.API.Mapping
{
    public class TournamentMappingsProfile : Profile
    {
        public TournamentMappingsProfile()
        {
            CreateMap<TournamentDto, TournamentModel>()
                .ForMember(d => d.DataTournamentInit, map => map.MapFrom(m => m.DataTournamentInit.ToShortDateString()))
                .ForMember(d => d.DataTournamentEnd, map => map.MapFrom(m => m.DataTournamentEnd.ToShortDateString()))
                .ForMember(d => d.GameType, map => map.MapFrom(m => m.GameType))
                .ForMember(d => d.GameTypeId, map => map.MapFrom(m => m.GameTypeId));
            CreateMap<CreatingTournamentModel, CreatingTournamentDto>();
            CreateMap<UpdatingTournamentModel, UpdatingTournamentDto>();
        }
    }
}

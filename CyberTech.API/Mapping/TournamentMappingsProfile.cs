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
                .ForMember(d => d.DateTournamentInit, map => map.MapFrom(m => m.DateTournamentInit.ToShortDateString()))
                .ForMember(d => d.DateTournamentEnd, map => map.MapFrom(m => m.DateTournamentEnd.ToShortDateString()))
                .ForMember(d => d.GameType, map => map.MapFrom(m => m.GameType))
                .ForMember(d => d.GameTypeId, map => map.MapFrom(m => m.GameTypeId));
            CreateMap<CreatingTournamentModel, CreatingTournamentDto>();
            CreateMap<UpdatingTournamentModel, UpdatingTournamentDto>();
        }
    }
}

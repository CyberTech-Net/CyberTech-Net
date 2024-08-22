using AutoMapper;
using CyberTech.API.ModelViews.Tournament;
using CyberTech.Core.Dto.Tournament;

namespace CyberTech.API.Mapping
{
    public class TournamentMapper : Profile
    {
        public TournamentMapper()
        {
            CreateMap<TournamentDto, TournamentModel>()
                .ForMember(d => d.DateTournamentInit, map => map.MapFrom(m => m.DateTournamentInit.ToShortDateString()))
                .ForMember(d => d.DateTournamentEnd, map => map.MapFrom(m => m.DateTournamentEnd.ToShortDateString()))
                .ForMember(d => d.GameType, map => map.MapFrom(m => m.GameType));
            CreateMap<CreatingTournamentModel, CreatingTournamentDto>();
            CreateMap<UpdatingTournamentModel, UpdatingTournamentDto>();
        }
    }
}

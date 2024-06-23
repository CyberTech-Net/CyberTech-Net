using AutoMapper;
using CyberTech.API.ModelViews.Player;
using CyberTech.Core.Dto.Player;

namespace CyberTech.API.Mapping
{
    public class PlayerMappingsProfile : Profile
    {
        public PlayerMappingsProfile()
        {
            CreateMap<PlayerDto, PlayerModel>()
                .ForMember(d => d.BirthDate, map => map.MapFrom(m => m.BirthDate.ToShortDateString()))
                .ForMember(d=>d.Country, map=>map.MapFrom(m=>m.Country))
                .ForMember(d=>d.CountryId, map=>map.MapFrom(m => m.CountryId));
            CreateMap<CreatingPlayerModel, CreatingPlayerDto>();
            CreateMap<UpdatingPlayerModel, UpdatingPlayerDto>();
        }
    }
}

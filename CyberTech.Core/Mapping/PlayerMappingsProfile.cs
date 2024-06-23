using AutoMapper;
using CyberTech.Core.Dto.Player;
using CyberTech.Domain.Entities;

namespace CyberTech.Core.Mapping
{
    public class PlayerMappingsProfile : Profile
    {
        public PlayerMappingsProfile()
        {
            CreateMap<PlayerEntity, PlayerDto>()
                .ForMember(d=>d.Country, map=>map.MapFrom(m=>m.Country.TitleCountry))
                .ForMember(d => d.CountryId, map => map.MapFrom(m => m.CountryId));

            CreateMap<CreatingPlayerDto, PlayerEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.TeamPlayers, map => map.Ignore())
                .ForMember(d => d.MongoPlayerPic, map => map.Ignore())
                .ForMember(d => d.CountryId, map => map.MapFrom(m => m.CountryId))
                .ForMember(d => d.Country, map => map.Ignore());

            CreateMap<UpdatingPlayerDto, PlayerEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.TeamPlayers, map => map.Ignore())
                .ForMember(d => d.MongoPlayerPic, map => map.Ignore())
                .ForMember(d => d.CountryId, map => map.MapFrom(m => m.CountryId))
                .ForMember(d => d.Country, map => map.Ignore());
        }
    }
}

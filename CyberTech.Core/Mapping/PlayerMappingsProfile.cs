using AutoMapper;
using CyberTech.Core.Dto.Player;
using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.Core.Mapping
{
    public class PlayerMappingsProfile : Profile
    {
        public PlayerMappingsProfile()
        {
            CreateMap<Player, PlayerDto>()
                .ForMember(d=>d.Country, map=>map.MapFrom(m=>m.Country.TitleCountry))
                .ForMember(d => d.CountryId, map => map.MapFrom(m => m.CountryId));

            CreateMap<CreatingPlayerDto, Player>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.TeamPlayers, map => map.Ignore())
                .ForMember(d => d.MongoPlayerPic, map => map.Ignore())
                .ForMember(d => d.CountryId, map => map.MapFrom(m => m.CountryId))
                .ForMember(d => d.Country, map => map.Ignore());

            CreateMap<UpdatingPlayerDto, Player>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.TeamPlayers, map => map.Ignore())
                .ForMember(d => d.MongoPlayerPic, map => map.Ignore())
                .ForMember(d => d.CountryId, map => map.MapFrom(m => m.CountryId))
                .ForMember(d => d.Country, map => map.Ignore());
        }
    }
}

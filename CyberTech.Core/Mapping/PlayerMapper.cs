using AutoMapper;
using CyberTech.Core.Dto.Player;
using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.Core.Mapping
{
    public class PlayerMapper : Profile
    {
        public PlayerMapper()
        {
            CreateMap<PlayerEntity, PlayerDto>();

            CreateMap<CreatingPlayerDto, PlayerEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.TeamPlayers, map => map.Ignore())                
                .ForMember(d => d.Country, map => map.Ignore());

            CreateMap<UpdatingPlayerDto, PlayerEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.TeamPlayers, map => map.Ignore())                
                .ForMember(d => d.Country, map => map.Ignore());
        }
    }
}

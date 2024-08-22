using AutoMapper;
using CyberTech.Core.Dto.GameType;
using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.Core.Mapping
{
    public class GameTypeMapper : Profile
    {
        public GameTypeMapper()
        {
            CreateMap<GameTypeEntity, GameTypeDto> ();

            CreateMap<CreatingGameTypeDto, GameTypeEntity>()
                .ForMember(d => d.Id, map => map.Ignore())                
                .ForMember(d => d.Tournaments, map => map.Ignore());

            CreateMap<UpdatingGameTypeDto, GameTypeEntity>()
                .ForMember(d => d.Id, map => map.Ignore())                
                .ForMember(d => d.Tournaments, map => map.Ignore());
        }
    }
}

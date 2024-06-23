using AutoMapper;
using CyberTech.Core.Dto.GameType;
using CyberTech.Domain.Entities;

namespace CyberTech.Core.Mapping
{
    public class GameTypeMappingsProfile : Profile
    {
        public GameTypeMappingsProfile()
        {
            CreateMap<GameTypeEntity, GameTypeDto> ();

            CreateMap<CreatingGameTypeDto, GameTypeEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.MongoGameTypePic, map => map.Ignore())
                .ForMember(d => d.Tournaments, map => map.Ignore());

            CreateMap<UpdatingGameTypeDto, GameTypeEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.MongoGameTypePic, map => map.Ignore())
                .ForMember(d => d.Tournaments, map => map.Ignore());
        }
    }
}

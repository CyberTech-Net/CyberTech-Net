using AutoMapper;
using CyberTech.Core.Dto.GameType;
using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.Core.Mapping
{
    public class GameTypeMappingsProfile : Profile
    {
        public GameTypeMappingsProfile()
        {
            CreateMap<Game, GameTypeDto> ();

            CreateMap<CreatingGameTypeDto, Game>()
                .ForMember(d => d.Id, map => map.Ignore())
             //   .ForMember(d => d.ImageId, map => map.Ignore())
                .ForMember(d => d.Tournaments, map => map.Ignore());

            CreateMap<UpdatingGameTypeDto, Game>()
                .ForMember(d => d.Id, map => map.Ignore())
          //      .ForMember(d => d.ImageId, map => map.Ignore())
                .ForMember(d => d.Tournaments, map => map.Ignore());
        }
    }
}

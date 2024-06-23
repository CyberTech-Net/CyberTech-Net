using AutoMapper;
using CyberTech.API.ModelViews.GameType;
using CyberTech.Core.Dto.GameType;

namespace CyberTech.API.Mapping
{
    public class GameTypeMappingsProfile : Profile
    {
        public GameTypeMappingsProfile()
        {
            CreateMap<GameTypeDto, GameTypeModel>();
            CreateMap<CreatingGameTypeModel, CreatingGameTypeDto>();
            CreateMap<UpdatingGameTypeModel, UpdatingGameTypeDto>();
        }
    }
}

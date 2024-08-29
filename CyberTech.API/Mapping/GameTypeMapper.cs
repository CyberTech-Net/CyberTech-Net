using AutoMapper;
using CyberTech.API.ModelViews.GameType;
using CyberTech.Core.Dto.GameType;

namespace CyberTech.API.Mapping
{
    public class GameTypeMapper : Profile
    {
        public GameTypeMapper()
        {
            CreateMap<GameTypeDto, GameTypeModel>();
            CreateMap<CreatingGameTypeModel, CreatingGameTypeDto>();
            CreateMap<UpdatingGameTypeModel, UpdatingGameTypeDto>();
        }
    }
}

using CyberTech.API.ModelViews.Match;
using CyberTech.Core.Dto.Match;
using AutoMapper;

namespace CyberTech.API.Mapping
{
    public class MatchMapper : Profile
    {
        public MatchMapper()
        {
            CreateMap<MatchDto, MatchModel>();
            CreateMap<CreatingMatchModel, CreatingMatchDto>();
            CreateMap<UpdatingMatchModel, UpdatingMatchDto>();
        }        
    }
}

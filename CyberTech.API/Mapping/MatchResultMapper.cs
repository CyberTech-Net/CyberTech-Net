using CyberTech.API.ModelViews.MatchResult;
using CyberTech.Core.Dto.MatchResult;
using AutoMapper;

namespace CyberTech.API.Mapping
{
    public class MatchResultMapper: Profile
    {
        public MatchResultMapper()
        {
            CreateMap<MatchResultDto, MatchResultModel>();
            CreateMap<CreatingMatchResultModel, CreatingMatchResultDto>();
            CreateMap<UpdatingMatchResultModel, UpdatingMatchResultDto>();
        }        
    }
}

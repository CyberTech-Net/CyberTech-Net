using AutoMapper;
using CyberTech.Core.Dto.MatchResult;
using CyberTech.Domain.Models.Tournaments;

namespace CyberTech.Core.Mapping
{
    public class MatchResultMapper: Profile
    {
        public MatchResultMapper()
        {
            CreateMap<MatchResultEntity, MatchResultDto>();
             
            CreateMap<CreatingMatchResultDto, MatchResultEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Team, map => map.Ignore())
                .ForMember(d => d.Match, map => map.Ignore());                

            CreateMap<UpdatingMatchResultDto, MatchResultEntity>()
                    .ForMember(d => d.Id, map => map.Ignore())
                    .ForMember(d => d.Team, map => map.Ignore())
                    .ForMember(d => d.Match, map => map.Ignore())
                    .ForMember(d => d.TeamId, map=>map.Ignore())
                    .ForMember(d => d.MatchId, map => map.Ignore());
        }        
    }
}

using AutoMapper;
using CyberTech.Core.Dto.Match;
using CyberTech.Domain.Models.Tournaments;

namespace CyberTech.Core.Mapping
{
    public class MatchMapper :Profile
    {
        public MatchMapper()
        {
            CreateMap<MatchEntity, MatchDto>();

            CreateMap<CreatingMatchDto, MatchEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Tournament, map => map.Ignore())
                .ForMember(d => d.MatchResults, map => map.Ignore())
                .ForMember(d => d.FirstTeam, map => map.Ignore())
                .ForMember(d => d.SecondTeam, map => map.Ignore());

            CreateMap<UpdatingMatchDto, MatchEntity>()
                    .ForMember(d => d.Id, map => map.Ignore())
                    .ForMember(d => d.Tournament, map => map.Ignore())
                    .ForMember(d => d.MatchResults, map => map.Ignore())
                    .ForMember(d => d.FirstTeam, map => map.Ignore())
                    .ForMember(d => d.SecondTeam, map => map.Ignore())
                    .ForMember(d => d.FirstTeamId, map => map.Ignore())
                    .ForMember(d => d.SecondTeamId, map => map.Ignore());
        }
    }
}

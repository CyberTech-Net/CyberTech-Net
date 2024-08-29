using AutoMapper;
using CyberTech.Core.Dto.TeamPlayer;
using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.Core.Mapping
{
    public class TeamPlayerMapper: Profile
    {
        public TeamPlayerMapper()
        {
            CreateMap<TeamPlayerEntity, TeamPlayerDto>();

            CreateMap<CreatingTeamPlayerDto, TeamPlayerEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Player, map => map.Ignore())
                .ForMember(d => d.Team, map => map.Ignore());

            CreateMap<UpdatingTeamPlayerDto, TeamPlayerEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Player, map => map.Ignore())
                .ForMember(d => d.Team, map => map.Ignore());
        }
    }
}

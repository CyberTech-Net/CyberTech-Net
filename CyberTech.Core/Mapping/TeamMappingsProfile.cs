using AutoMapper;
using CyberTech.Core.Dto.Team;
using CyberTech.Domain.Entities;

namespace CyberTech.Core.Mapping
{
    public class TeamMappingsProfile : Profile
    {
        public TeamMappingsProfile()
        {
            CreateMap<TeamEntity, TeamDto>();

            CreateMap<CreatingTeamDto, TeamEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.TeamPlayers, map => map.Ignore())
                .ForMember(d => d.TournamentMeetTeams, map => map.Ignore());

            CreateMap<UpdatingTeamDto, TeamEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.TeamPlayers, map => map.Ignore())
                .ForMember(d => d.TournamentMeetTeams, map => map.Ignore());
        }
    }
}

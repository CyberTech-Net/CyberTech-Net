using AutoMapper;
using CyberTech.Core.Dto.Team;
using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.Core.Mapping
{
    public class TeamMappingsProfile : Profile
    {
        public TeamMappingsProfile()
        {
            CreateMap<Team, TeamDto>();

            CreateMap<CreatingTeamDto, Team>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.TeamPlayers, map => map.Ignore())
                .ForMember(d => d.TournamentMeetTeams, map => map.Ignore());

            CreateMap<UpdatingTeamDto, Team>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.TeamPlayers, map => map.Ignore())
                .ForMember(d => d.TournamentMeetTeams, map => map.Ignore());
        }
    }

    public static class TeamMapper
    {
        public static TeamDto ConvertToDto(Team dbEntity)
        {
            return new TeamDto()
            {
                Id = dbEntity.Id,
                TitleTeam = dbEntity.TitleTeam,
                Founded = dbEntity.Founded
            };
        }
    }
}

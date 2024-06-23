using AutoMapper;
using CyberTech.Core.Dto.TeamPlayer;
using CyberTech.Domain.Entities;

namespace CyberTech.Core.Mapping
{
    public class TeamPlayerMappingsProfile:Profile
    {
        public TeamPlayerMappingsProfile()
        {
            CreateMap<TeamPlayerEntity, TeamPlayerDto>()
                .ForMember(d => d.TitleTeam, map => map.MapFrom(m => m.Team.TitleTeam))
                .ForMember(d => d.FIO, map => map.MapFrom(m => 
                String.Concat(m.Player.FirstName," ", m.Player.SecondName)));

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

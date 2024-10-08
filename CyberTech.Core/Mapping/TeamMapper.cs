﻿using AutoMapper;
using CyberTech.Core.Dto.Team;
using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.Core.Mapping
{
    public class TeamMapper : Profile
    {
        public TeamMapper()
        {
            CreateMap<TeamEntity, TeamDto>();

            CreateMap<CreatingTeamDto, TeamEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.TeamPlayers, map => map.Ignore())
                .ForMember(d => d.MatchResults, map => map.Ignore());

            CreateMap<UpdatingTeamDto, TeamEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.TeamPlayers, map => map.Ignore())
                .ForMember(d => d.MatchResults, map => map.Ignore());
        }
    }
}

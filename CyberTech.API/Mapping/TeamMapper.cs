﻿using AutoMapper;
using CyberTech.API.ModelViews.Team;
using CyberTech.Core.Dto.Team;

namespace CyberTech.API.Mapping
{
    public class TeamMapper : Profile
    {
        public TeamMapper()
        {
            CreateMap<TeamDto, TeamModel>()
                .ForMember(d => d.Founded, map => map.MapFrom(m => m.Founded.ToShortDateString()));
            CreateMap<CreatingTeamModel, CreatingTeamDto>();
            CreateMap<UpdatingTeamModel, UpdatingTeamDto>();
        }
    }
}

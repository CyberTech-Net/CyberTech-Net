using AutoMapper;
using CyberTech.API.ModelViews.TeamPlayer;
using CyberTech.Core.Dto.TeamPlayer;

namespace CyberTech.API.Mapping
{
    public class TeamPlayerMappingsProfile: Profile
    {
        public TeamPlayerMappingsProfile()
        {
            CreateMap<TeamPlayerDto, TeamPlayerModel>()
                     .ForMember(d => d.TitleTeam, map => map.MapFrom(m => m.TitleTeam))
                     .ForMember(d => d.Year1, map => map.MapFrom(m=>m.Year1.ToString()))
                     .ForMember(d => d.Year2, map => map.MapFrom(m => m.Year2.ToString()))
                     .ForMember(d => d.FIO, map => map.MapFrom(m => m.FIO));
            CreateMap<CreatingTeamPlayerModel, CreatingTeamPlayerDto>()
                     .ForMember(d => d.Year1, map => map.MapFrom(m => Int32.Parse(m.Year1)))
                     .ForMember(d => d.Year2, map => map.MapFrom(m => m.Year2.Equals("") ? null : m.Year2.ToString()));
            CreateMap<UpdatingTeamPlayerModel, UpdatingTeamPlayerDto>()
                     .ForMember(d => d.Year1, map => map.MapFrom(m => Int32.Parse(m.Year1)))
                     .ForMember(d => d.Year2, map => map.MapFrom(m => m.Year2.Equals("") ? null : m.Year2.ToString()));
        }
    }
}

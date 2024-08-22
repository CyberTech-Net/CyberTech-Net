using AutoMapper;
using CyberTech.API.ModelViews.TeamPlayer;
using CyberTech.Core.Dto.TeamPlayer;

namespace CyberTech.API.Mapping
{
    public class TeamPlayerMapper : Profile
    {
        public TeamPlayerMapper()
        {
            CreateMap<TeamPlayerDto, TeamPlayerModel>()                     
                     .ForMember(d => d.Year1, map => map.MapFrom(m => m.Year1.ToString()))
                     .ForMember(d => d.Year2, map => map.MapFrom(m => m.Year2.ToString()))
                     .ForMember(d => d.FIO, map => map.MapFrom(m => String.Concat(m.Player.FirstName," ",m.Player.SecondName)));
            CreateMap<CreatingTeamPlayerModel, CreatingTeamPlayerDto>()
                     .ForMember(d => d.Year1, map => map.MapFrom(m => Int32.Parse(m.Year1)))
                     .ForMember(d => d.Year2, map => map.MapFrom(m => m.Year2.Equals("") ? null : m.Year2.ToString()));
            CreateMap<UpdatingTeamPlayerModel, UpdatingTeamPlayerDto>()
                     .ForMember(d => d.Year1, map => map.MapFrom(m => Int32.Parse(m.Year1)))
                     .ForMember(d => d.Year2, map => map.MapFrom(m => m.Year2.Equals("") ? null : m.Year2.ToString()));
        }
    }
}

using AutoMapper;
using CyberTech.API.ModelViews.TournamentMeetTeam;
using CyberTech.Core.Dto.TournamentMeetTeam;

namespace CyberTech.API.Mapping
{
    public class TournamentMeetTeamMappingsProfile : Profile
    {
        public TournamentMeetTeamMappingsProfile()
        {
            CreateMap<TournamentMeetTeamDto, TournamentMeetTeamModel>()
                .ForMember(d => d.DataTournamentMeet, map => map.MapFrom(m => m.DataTournamentMeet.ToShortDateString()))
                .ForMember(d => d.TitleTournament, map => map.MapFrom(m => m.TitleTournament))
                .ForMember(d=>d.TitleTeam, map => map.MapFrom(m => m.TitleTeam))
                .ForMember(d => d.Win, map => map.MapFrom(m => m.Win ? "победа" : "проигрыш"))
                .ForMember(d => d.GenComplete, map => map.MapFrom(m => m.GenComplete ? "готово" : "не готово"));
            CreateMap<CreatingTournamentMeetTeamModel, CreatingTournamentMeetTeamDto>()
                .ForMember(d => d.Win, map => map.MapFrom(m => m.Win == 1 ? true : false))
                .ForMember(d => d.GenComplete, map => map.MapFrom(m => m.GenComplete == 1 ? true : false));                
            CreateMap<UpdatingTournamentMeetTeamModel, UpdatingTournamentMeetTeamDto>()
                .ForMember(d => d.Win, map => map.MapFrom(m => m.Win==1 ? true : false))
                .ForMember(d => d.GenComplete, map => map.MapFrom(m => m.GenComplete == 1 ? true : false));
        }
    }
}

using AutoMapper;
using CyberTech.Core.Dto.TournamentMeetTeam;
using CyberTech.Domain.Entities;

namespace CyberTech.Core.Mapping
{
    public class TournamentMeetTeamMappingsProfile : Profile
    {
        public TournamentMeetTeamMappingsProfile()
        {
            CreateMap<TournamentMeetTeamEntity, TournamentMeetTeamDto>()
               .ForMember(d => d.TournamentMeetId, map => map.MapFrom(m => m.TournamentMeetId))
               .ForMember(d=>d.DataTournamentMeet, map => map.MapFrom(m => m.TournamentMeet.DataTournamentMeet))
               .ForMember(d => d.TitleTournament, map => map.MapFrom(m => m.TournamentMeet.Tournament))
               .ForMember(d => d.TeamId, map => map.MapFrom(m => m.TeamId))
               .ForMember(d => d.TitleTeam, map => map.MapFrom(m => m.Team.TitleTeam));

            CreateMap<CreatingTournamentMeetTeamDto, TournamentMeetTeamEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.TournamentMeetId, map => map.MapFrom(m => m.TournamentMeetId))
                .ForMember(d => d.TournamentMeet, map => map.Ignore())
                .ForMember(d => d.TeamId, map => map.MapFrom(m => m.TeamId))
                .ForMember(d => d.Team, map => map.Ignore());

            CreateMap<UpdatingTournamentMeetTeamDto, TournamentMeetTeamEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.TournamentMeetId, map => map.MapFrom(m => m.TournamentMeetId))
                .ForMember(d => d.TournamentMeet, map => map.Ignore())
                .ForMember(d => d.TeamId, map => map.MapFrom(m => m.TeamId))
                .ForMember(d => d.Team, map => map.Ignore());
        }
    }
}

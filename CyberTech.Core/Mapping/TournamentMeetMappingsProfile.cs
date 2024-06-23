using AutoMapper;
using CyberTech.Core.Dto.TournamentMeet;
using CyberTech.Domain.Entities;

namespace CyberTech.Core.Mapping
{
    public class TournamentMeetMappingsProfile : Profile
    {
        public TournamentMeetMappingsProfile()
        {
            CreateMap<TournamentMeetEntity, TournamentMeetDto>()
                .ForMember(d => d.Tournament, map => map.MapFrom(m => m.Tournament.TitleTournament))
                .ForMember(d => d.TournamentId, map => map.MapFrom(m => m.TournamentId));

            CreateMap<CreatingTournamentMeetDto, TournamentMeetEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.TournamentMeetTeams, map => map.Ignore())
                .ForMember(d => d.TournamentId, map => map.MapFrom(m => m.TournamentId))
                .ForMember(d => d.Tournament, map => map.Ignore());

            CreateMap<UpdatingTournamentMeetDto, TournamentMeetEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.TournamentMeetTeams, map => map.Ignore())
                .ForMember(d => d.TournamentId, map => map.MapFrom(m => m.TournamentId))
                .ForMember(d => d.Tournament, map => map.Ignore());
        }
    }
}

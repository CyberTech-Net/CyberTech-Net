using AutoMapper;
using CyberTech.Core.Dto.Tournament;
using CyberTech.Domain.Models.Tournaments;

namespace CyberTech.Core.Mapping
{
    public class TournamentMappingsProfile : Profile
    {
        public TournamentMappingsProfile()
        {
            CreateMap<Tournament, TournamentDto>()
                .ForMember(d => d.GameType, map => map.MapFrom(m => m.GameType.TitleGame))
                .ForMember(d => d.GameTypeId, map => map.MapFrom(m => m.GameTypeId));

            CreateMap<CreatingTournamentDto, Tournament>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Matches, map => map.Ignore())
                .ForMember(d => d.GameTypeId, map => map.MapFrom(m => m.GameTypeId))
                .ForMember(d => d.MongoChat, map => map.Ignore())
                .ForMember(d => d.GameType, map => map.Ignore());

            CreateMap<UpdatingTournamentDto, Tournament>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Matches, map => map.Ignore())
                .ForMember(d => d.GameTypeId, map => map.MapFrom(m => m.GameTypeId))
                .ForMember(d => d.MongoChat, map => map.Ignore())
                .ForMember(d => d.GameType, map => map.Ignore());
        }
    }
}

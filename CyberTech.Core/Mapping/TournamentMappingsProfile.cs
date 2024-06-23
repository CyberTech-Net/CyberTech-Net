using AutoMapper;
using CyberTech.Core.Dto.Tournament;
using CyberTech.Domain.Entities;

namespace CyberTech.Core.Mapping
{
    public class TournamentMappingsProfile : Profile
    {
        public TournamentMappingsProfile()
        {
            CreateMap<TournamentEntity, TournamentDto>()
                .ForMember(d => d.GameType, map => map.MapFrom(m => m.GameType.TitleGame))
                .ForMember(d => d.GameTypeId, map => map.MapFrom(m => m.GameTypeId));

            CreateMap<CreatingTournamentDto, TournamentEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.TournamentMeets, map => map.Ignore())
                .ForMember(d => d.GameTypeId, map => map.MapFrom(m => m.GameTypeId))
                .ForMember(d => d.MongoChat, map => map.Ignore())
                .ForMember(d => d.GameType, map => map.Ignore());

            CreateMap<UpdatingTournamentDto, TournamentEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.TournamentMeets, map => map.Ignore())
                .ForMember(d => d.GameTypeId, map => map.MapFrom(m => m.GameTypeId))
                .ForMember(d => d.MongoChat, map => map.Ignore())
                .ForMember(d => d.GameType, map => map.Ignore());
        }
    }
}

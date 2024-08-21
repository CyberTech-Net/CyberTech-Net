using AutoMapper;
using CyberTech.Core.Dto.Tournament;
using CyberTech.Domain.Models.Tournaments;

namespace CyberTech.Core.Mapping
{
    public class TournamentMapper : Profile
    {
        public TournamentMapper()
        {
            CreateMap<TournamentEntity, TournamentDto>();

            CreateMap<CreatingTournamentDto, TournamentEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Matches, map => map.Ignore())                
                .ForMember(d => d.GameType, map => map.Ignore());

            CreateMap<UpdatingTournamentDto, TournamentEntity>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Matches, map => map.Ignore())                
                .ForMember(d => d.GameType, map => map.Ignore());
        }
    }
}

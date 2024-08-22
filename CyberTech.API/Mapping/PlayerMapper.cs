using AutoMapper;
using CyberTech.API.ModelViews.Player;
using CyberTech.Core.Dto.Player;

namespace CyberTech.API.Mapping
{
    public class PlayerMapper : Profile
    {
        public PlayerMapper()
        {
            CreateMap<PlayerDto, PlayerModel>()
                .ForMember(d => d.BirthDate, map => map.MapFrom(m => m.BirthDate.ToShortDateString()));
            CreateMap<CreatingPlayerModel, CreatingPlayerDto>();
            CreateMap<UpdatingPlayerModel, UpdatingPlayerDto>();
        }
    }
}

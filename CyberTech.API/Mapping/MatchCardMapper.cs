using AutoMapper;
using CyberTech.API.ModelViews.MatchCard;
using CyberTech.Core.Dto.MatchCard;

namespace CyberTech.API.Mapping
{
    public class MatchCardMapper : Profile
    {
        public MatchCardMapper()
        {
            CreateMap<MatchCardDto, MatchCardModel>();
        }
    }
}

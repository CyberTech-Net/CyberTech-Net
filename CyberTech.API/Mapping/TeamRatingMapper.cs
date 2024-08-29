using AutoMapper;
using CyberTech.API.ModelViews.TeamPlayer;
using CyberTech.Core.Dto.TeamRating;

namespace CyberTech.API.Mapping
{
    public class TeamRatingMapper : Profile
    {
        public TeamRatingMapper()
        {
            CreateMap<TeamRatingDto, TeamRatingModel>();
        }
    }
}

using CyberTech.Core.Dto.TeamRating;

namespace CyberTech.Core.IServices
{
    public interface ITeamRatingService
    {
        Task<ICollection<TeamRatingDto>> GetTeamRating();
    }
}
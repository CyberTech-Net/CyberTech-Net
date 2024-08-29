using CyberTech.API.ModelViews.Player;
using CyberTech.API.ModelViews.Team;

namespace CyberTech.API.ModelViews.TeamPlayer
{
    public class TeamRatingModel
    {
        public Guid Id { get; set; }        
        public string TeamNaim { get; set; }
        public int Score { get; set; }
        public int WinCount { get; set; }
        public int LoseCount { get; set; }
        public int MatchCount { get; set; }
        public DateTime? LastMatch { get; set; }
        public DateTime? FutureMatch { get; set;}
        public string ImageId { get; set; }
    }
}

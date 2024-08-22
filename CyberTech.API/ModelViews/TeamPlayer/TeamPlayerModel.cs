using CyberTech.API.ModelViews.Player;
using CyberTech.API.ModelViews.Team;

namespace CyberTech.API.ModelViews.TeamPlayer
{
    public class TeamPlayerModel
    {
        public Guid Id { get; set; }        
        public TeamModel Team { get; set; }
        public PlayerModel Player { get; set; }
        public string FIO { get; set; }
        public string Year1 { get; set; }
        public string Year2 { get; set; }
    }
}

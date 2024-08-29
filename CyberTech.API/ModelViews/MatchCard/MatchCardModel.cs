using CyberTech.API.ModelViews.Team;
using CyberTech.API.ModelViews.Tournament;

namespace CyberTech.API.ModelViews.MatchCard
{
    public class MatchCardModel
    {
        public Guid Id { get; set; }
        public TeamModel FirstTeam { get; set; }
        public TeamModel SecondTeam { get; set; }
        public string FirstTeamResult { get; set; }
        public TournamentModel Tournament { get; set; }
        public string SecondTeamResult { get; set; }
        public int FirstTeamScore { get; set; }
        public int SecondTeamScore { get; set; }
        public DateTime StartDateTime { get; set; }
    }
}

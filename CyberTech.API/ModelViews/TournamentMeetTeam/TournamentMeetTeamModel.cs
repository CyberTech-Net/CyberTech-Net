namespace CyberTech.API.ModelViews.TournamentMeetTeam
{
    public class TournamentMeetTeamModel
    {
        public Guid TournamentMeetId { get; set; }
        public string TitleTournament { get; set; }
        public DateTime DataTournamentMeet { get; set; }
        public Guid TeamId { get; set; }
        public string TitleTeam { get; set; }
        public int ScoreTeam { get; set; }
        public decimal EarndTeam { get; set; }
        public int RatingTeam { get; set; }
        public string Win { get; set; }
    }
}

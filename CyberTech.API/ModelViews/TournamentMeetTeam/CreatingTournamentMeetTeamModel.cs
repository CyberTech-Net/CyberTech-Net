namespace CyberTech.API.ModelViews.TournamentMeetTeam
{
    public class CreatingTournamentMeetTeamModel
    {
        public Guid TournamentMeetId { get; set; }
        public Guid TeamId { get; set; }
        public int ScoreTeam { get; set; }
        public decimal EarndTeam { get; set; }
        public int RatingTeam { get; set; }
        public byte Win { get; set; }
    }
}

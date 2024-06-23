namespace CyberTech.Core.Dto.TournamentMeetTeam
{
    public class CreatingTournamentMeetTeamDto
    {
        public Guid TournamentMeetId { get; set; }
        public Guid TeamId { get; set; }
        public int ScoreTeam { get; set; }
        public decimal EarndTeam { get; set; }
        public int RatingTeam { get; set; }
        public bool Win { get; set; }
    }
}

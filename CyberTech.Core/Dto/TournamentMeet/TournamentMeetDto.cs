namespace CyberTech.Core.Dto.TournamentMeet
{
    public class TournamentMeetDto
    {
        public Guid Id { get; set; }
        public DateTime DataTournamentMeet { get; set; }
        public Guid TournamentId { get; set; }
        public string Tournament { get; set; }
    }
}

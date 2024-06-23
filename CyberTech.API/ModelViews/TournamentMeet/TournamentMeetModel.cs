namespace CyberTech.API.ModelViews.TournamentMeet
{
    public class TournamentMeetModel
    {
        public Guid Id { get; set; }
        public Guid TournamentId { get; set; }
        public string DataTournamentMeet { get; set; }
        public string Tournament{ get; set; }
    }
}

namespace CyberTech.API.ModelViews.Tournament
{
    public class CreatingTournamentModel
    {
        public Guid GameTypeId { get; set; }
        public string TitleTournament { get; set; }
        public string TypeTournament { get; set; }
        public string DataTournamentInit { get; set; }
        public string DataTournamentEnd { get; set; }
        public string PlaceName { get; set; }
        public decimal EarndTournament { get; set; }
    }
}

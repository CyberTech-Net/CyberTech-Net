namespace CyberTech.API.ModelViews.Tournament
{
    public class CreatingTournamentModel
    {
        public Guid GameTypeId { get; set; }
        public string TitleTournament { get; set; }
        public string TypeTournament { get; set; }
        public DateTime DateTournamentInit { get; set; }
        public DateTime DateTournamentEnd { get; set; }
        public string PlaceName { get; set; }
        public decimal EarndTournament { get; set; }
    }
}

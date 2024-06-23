namespace CyberTech.API.ModelViews.Tournament
{
    public class TournamentPaginationModel
    {
        public string TitleTournament { get; set; }
        public string TypeTournament { get; set; }
        public string GameType { get; set; }
        public string DataTournamentInit { get; set; }
        public string DataTournamentEnd { get; set; }
        public string PlaceName { get; set; }
        public decimal EarndTournament { get; set; }
        public int ItemsPerPage { get; set; }
        public int Page { get; set; }
    }
}

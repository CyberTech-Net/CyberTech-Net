using CyberTech.API.ModelViews.GameType;

namespace CyberTech.API.ModelViews.Tournament
{
    public class TournamentPaginationModel
    {
        public string TitleTournament { get; set; }
        public string TypeTournament { get; set; }
        public GameTypeModel GameType { get; set; }
        public DateTime DateTournamentInit { get; set; }
        public DateTime DateTournamentEnd { get; set; }
        public string PlaceName { get; set; }
        public decimal EarndTournament { get; set; }
        public int ItemsPerPage { get; set; }
        public int Page { get; set; }
    }
}

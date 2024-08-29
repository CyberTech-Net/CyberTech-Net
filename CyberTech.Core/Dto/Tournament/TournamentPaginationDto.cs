using CyberTech.Core.Dto.GameType;

namespace CyberTech.Core.Dto.Tournament
{
    public class TournamentPaginationDto
    {
        public string TitleTournament { get; set; }
        public string TypeTournament { get; set; }
        public DateTime DateTournamentInit { get; set; }
        public DateTime DateTournamentEnd { get; set; }
        public string PlaceName { get; set; }
        public decimal EarndTournament { get; set; }
        public GameTypeDto GameType { get; set; }
        public int ItemsPerPage { get; set; }
        public int Page { get; set; }
    }
}

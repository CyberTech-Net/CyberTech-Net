using CyberTech.API.ModelViews.Country;
using CyberTech.API.ModelViews.GameType;

namespace CyberTech.API.ModelViews.Tournament
{
    public class TournamentModel
    {
        public Guid Id { get; set; }
        public string TitleTournament { get; set; }
        public string TypeTournament { get; set; }        
        public string DateTournamentInit { get; set; }
        public string DateTournamentEnd { get; set; }
        public string PlaceName { get; set; }
        public decimal EarndTournament { get; set; }
        public GameTypeModel GameType { get; set; }
    }
}

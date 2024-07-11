﻿namespace CyberTech.Core.Dto.Tournament
{
    public class UpdatingTournamentDto
    {
        public string TitleTournament { get; set; }
        public string TypeTournament { get; set; }
        public DateTime DataTournamentInit { get; set; }
        public DateTime DataTournamentEnd { get; set; }
        public string PlaceName { get; set; }
        public decimal EarndTournament { get; set; }
        public Guid GameTypeId { get; set; }
    }
}

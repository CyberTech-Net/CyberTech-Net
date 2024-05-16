namespace CyberTech.Core.Domain.Entities
{
    public class Tournament :BaseEntity
    {

        public string Name { get; set; }
        public string PlaceName { get; set; }
        public DateTime TourDateTime { get; set; }
        public double PrizFund { get; set; }
        public double TourRating { get; set; }  
        public Guid TourChatId { get; set; }            // mongoDB

        public virtual Game? Game { get; set; }
        public Guid? GameId { get; set; }
        public virtual ICollection<GameTeam>? GameTeams { get; set; }
    }
}

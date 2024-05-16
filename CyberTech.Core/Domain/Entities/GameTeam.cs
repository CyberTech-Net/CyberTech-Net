using CyberTech.Core.Domain.Administration;

namespace CyberTech.Core.Domain.Entities
{
    public class GameTeam: BaseEntity
    {
        public string Name { get; set; }    
        public DateTime Founded { get; set; }  = DateTime.Now;
        public double Score { get; set; }
        public double Earnd { get; set; }
        public double Rating { get; set; }
        public int Wins { get; set; }
        public int Looses { get; set; }
        public virtual Game? Game { get; set; }
        public Guid? GameId { get; set; }
        public virtual Tournament? Tournament { get; set; }
        public Guid? TournamentId { get; set; }
        public virtual ICollection<User>? Members { get; set; }
    }
}

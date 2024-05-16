using CyberTech.Core.Domain.Entities;

namespace CyberTech.Core.Domain.Administration
{
    public class User:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public double Earned { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<GameTeam>? GameTeams { get; set; }
    }
}

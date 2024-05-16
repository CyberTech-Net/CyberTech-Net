namespace CyberTech.Core.Domain.Entities
{
    public class Game : BaseEntity
    {
        public  string  Name { get; set; }
        public string Description { get; set; }
        public int MaxUserCnt { get; set; }          

        public virtual ICollection<GameTeam>? GameTeams { get; set; }
        public virtual ICollection<Tournament>? Tournaments { get; set; }
    }


}

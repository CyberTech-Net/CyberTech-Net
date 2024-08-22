namespace CyberTech.Core.Dto.TeamPlayer
{
    public class CreatingTeamPlayerDto
    {
        public Guid TeamId { get; set; }
        public Guid PlayerId { get; set; }
        public int Year1 { get; set; }
        public int? Year2 { get; set; }
    }
}

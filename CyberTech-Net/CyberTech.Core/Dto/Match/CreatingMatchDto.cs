namespace CyberTech.Core.Dto.Match
{
    public class CreatingMatchDto
    {
        public Guid TournamentId { get; set; }
        public DateTime StartDateTime { get; set; } 
        public Guid FirstTeamId { get; set; } 
        public Guid SecondTeamId { get; set; } 
    }
}

namespace CyberTech.Core.Dto.Match
{
    public class UpdatingMatchDto(Guid tournamentId, DateTime startDateTime)
    {
        public Guid TournamentId { get; set; } = tournamentId;
        public DateTime StartDateTime { get; set; } = startDateTime;
    }
}

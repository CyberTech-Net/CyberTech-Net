namespace CyberTech.Core.Dto.Match
{
    public class MatchDto(Guid id, DateTime startDateTime, Guid tournamentId)
    {
        public Guid Id { get; set; } = id;
        public DateTime StartDateTime { get; set; } = startDateTime;
        public Guid TournamentId { get; set; } = tournamentId;
    }
}

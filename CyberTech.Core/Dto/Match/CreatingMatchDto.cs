namespace CyberTech.Core.Dto.Match
{
    public class CreatingMatchDto(Guid tournamentId, DateTime startDateTime, Guid firtstTeamId, Guid secondTeamId)
    {
        public Guid TournamentId { get; set; } = tournamentId;
        public DateTime StartDateTime { get; set; } = startDateTime;

        /// <summary>
        /// Id команды.
        /// </summary>
        public Guid FirtstTeamId { get; set; } = firtstTeamId;

        /// <summary>
        /// Id команды.
        /// </summary>
        public Guid SecondTeamId { get; set; } = secondTeamId;
    }
}

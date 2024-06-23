namespace CyberTech.Domain.Entities
{
    /// <summary>
    /// Встреча турнира.
    /// </summary>
    public class TournamentMeetEntity : IEntity<Guid>
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id турнира.
        /// </summary>
        public Guid TournamentId { get; set; }

        /// <summary>
        /// Турнир.
        /// </summary>
        public virtual TournamentEntity Tournament { get; set; }

        /// <summary>
        /// Дата встречи.
        /// </summary>
        public DateTime DataTournamentMeet { get; set; }

        /// <summary>
        /// Команды встречи.
        /// </summary>
        public virtual List<TournamentMeetTeamEntity> TournamentMeetTeams { get; set; }
    }
}

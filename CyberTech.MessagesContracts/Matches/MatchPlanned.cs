namespace CyberTech.MessagesContracts.TournamentMeets
{
    /// <summary>
    /// Событие запланированной встречи
    /// </summary>
    public class MatchPlanned
    {
        /// <summary>
        /// Идентификатор игровой встречи
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Дата встречи
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Id команды.
        /// </summary>
        public Guid FirtstTeamId { get; set; } 

        /// <summary>
        /// Id команды.
        /// </summary>
        public Guid SecondTeamId { get; set; }
        
        public MatchPlanned(Guid id, DateTime date, Guid firtstTeamId, Guid secondTeamId)
        {
            Id = id;
            Date = date;
            FirtstTeamId = firtstTeamId;
            SecondTeamId = secondTeamId;
        }

        protected MatchPlanned()
        {

        }
    }
}

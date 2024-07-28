namespace CyberTech.API.ModelViews.Match
{
    /// <summary>
    /// Данные о турирной встрече
    /// </summary>
    public class MatchModel
    {
        /// <summary>
        /// Идентификатор встречи
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор турнира
        /// </summary>
        public Guid TournamentId { get; set; }

        /// <summary>
        /// Дата и время начала встречи
        /// </summary>
        public DateTime StartDateTime { get; set; }

        public MatchModel(Guid id, Guid tournamentId, DateTime startDateTime)
        {
            Id = id;
            TournamentId = tournamentId;
            StartDateTime = startDateTime;
        }

        protected MatchModel()
        {

        }
    }
}

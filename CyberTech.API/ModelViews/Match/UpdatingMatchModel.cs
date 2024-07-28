namespace CyberTech.API.ModelViews.Match
{
    /// <summary>
    /// Модель обновления встречи
    /// </summary>
    public class UpdatingMatchModel
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

        public UpdatingMatchModel(Guid tournamentId, DateTime startDateTime)
        {
            TournamentId = tournamentId;
            StartDateTime = startDateTime;
        }
        protected UpdatingMatchModel()
        {

        }
    }
}

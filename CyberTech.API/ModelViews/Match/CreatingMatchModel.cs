namespace CyberTech.API.ModelViews.Match
{
    /// <summary>
    /// Модель для создания встречи
    /// </summary>
    public class CreatingMatchModel
    {
        /// <summary>
        /// Идентификатор турнира
        /// </summary>
        public Guid TournamentId { get; set; }

        /// <summary>
        /// Дата и время начала встречи
        /// </summary>
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// Id команды.
        /// </summary>
        public Guid FirtstTeamId { get; set; }

        /// <summary>
        /// Id команды.
        /// </summary>
        public Guid SecondTeamId { get; set; }

        public CreatingMatchModel(Guid tournamentId, DateTime startDateTime, Guid firtstTeamId, Guid secondTeamId)
        {
            TournamentId = tournamentId;
            StartDateTime = startDateTime;
            FirtstTeamId = firtstTeamId;
            SecondTeamId = secondTeamId;
        }

        protected CreatingMatchModel()
        {

        }
    }
}

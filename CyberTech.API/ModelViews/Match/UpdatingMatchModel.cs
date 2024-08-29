namespace CyberTech.API.ModelViews.Match
{
    /// <summary>
    /// Модель обновления встречи
    /// </summary>
    public class UpdatingMatchModel
    {
        /// <summary>
        /// Идентификатор турнира
        /// </summary>
        public Guid TournamentId { get; set; }

        /// <summary>
        /// Дата и время начала встречи
        /// </summary>
        public DateTime StartDateTime { get; set; }       
    }
}

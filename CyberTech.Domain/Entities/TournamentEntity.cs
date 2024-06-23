namespace CyberTech.Domain.Entities
{
    /// <summary>
    /// Турнир.
    /// </summary>
    public class TournamentEntity : IEntity<Guid>
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id вида игры.
        /// </summary>
        public Guid GameTypeId { get; set; }

        /// <summary>
        /// Вид игры.
        /// </summary>
        public virtual GameTypeEntity GameType { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string TitleTournament { get; set; }

        /// <summary>
        /// Тип.
        /// </summary>
        public string TypeTournament { get; set; }

        /// <summary>
        /// Дата начала.
        /// </summary>
        public DateTime DataTournamentInit { get; set; }

        /// <summary>
        /// Дата окончания.
        /// </summary>
        public DateTime DataTournamentEnd { get; set; }

        /// <summary>
        /// Место проведения.
        /// </summary>
        public string PlaceName { get; set; }

        /// <summary>
        /// Призовой фонд.
        /// </summary>
        public decimal EarndTournament { get; set; }

        /// <summary>
        /// Чат турнира.
        /// </summary>
        public int? MongoChat { get; set; }            

        /// <summary>
        /// Встречи турнира.
        /// </summary>
        public virtual List<TournamentMeetEntity> TournamentMeets { get; set; }
    }
}

namespace CyberTech.Domain.Entities
{
    /// <summary>
    /// Вид игры.
    /// </summary>
    public class GameTypeEntity : IEntity<Guid>
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string TitleGame { get; set; } = string.Empty;

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Картинка с логотипом игры.
        /// </summary>
        public int? MongoGameTypePic { get; set; }

        /// <summary>
        /// Турниры.
        /// </summary>
        public virtual List<TournamentEntity>? Tournaments { get; set; }
    }
}

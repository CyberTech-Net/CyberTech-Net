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
        /// Картинка
        /// </summary>
        public string ImageId { get; set; }

        /// <summary>
        /// Турниры.
        /// </summary>
        public virtual List<TournamentEntity>? Tournaments { get; set; }
    }
}

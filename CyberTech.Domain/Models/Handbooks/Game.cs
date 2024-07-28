using CyberTech.Domain.Interfaces;
using CyberTech.Domain.Models.Tournaments;

namespace CyberTech.Domain.Models.Handbooks
{
    /// <summary>
    /// Вид игры.
    /// </summary>
    public class Game : IEntity<Guid>
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
        /// Жанр игры.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Картинка
        /// </summary>
        public string ImageId { get; set; }

        /// <summary>
        /// Турниры.
        /// </summary>
        public virtual List<Tournament>? Tournaments { get; set; }
    }
}

using CyberTech.Domain.Interfaces;

namespace CyberTech.Domain.Models.Handbooks
{
    /// <summary>
    /// Состав команды.
    /// </summary>
    public class TeamPlayer : IEntity<Guid>
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id игрока.
        /// </summary>
        public Guid PlayerId { get; set; }

        /// <summary>
        /// Игрок.
        /// </summary>
        public virtual Player Player { get; set; }

        /// <summary>
        /// Id команды.
        /// </summary>
        public Guid TeamId { get; set; }

        /// <summary>
        /// Команда.
        /// </summary>
        public virtual Team Team { get; set; }

        /// <summary>
        /// Год вступления в команду.
        /// </summary>
        public int Year1 { get; set; }

        /// <summary>
        /// Год выхода из команды.
        /// </summary>
        public int? Year2 { get; set; }
    }
}

using CyberTech.Domain.Interfaces;

namespace CyberTech.Domain.Models.Handbooks
{
    /// <summary>
    /// Роль пользователя.
    /// </summary>
    public class Role : IEntity<Guid>
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string TitleRole { get; set; } = string.Empty;

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Пользователи.
        /// </summary>
        public virtual List<User>? Users { get; set; }
    }
}

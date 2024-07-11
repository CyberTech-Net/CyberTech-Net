namespace CyberTech.Domain.Entities
{
    [Obsolete("Delete after creating the authorization server")]
    /// <summary>
    /// Роль пользователя.
    /// </summary>
    public class RoleEntity : IEntity<Guid>
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
        public virtual List<UserEntity>? Users { get; set; }
    }
}

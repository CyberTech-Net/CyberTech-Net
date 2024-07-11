
namespace CyberTech.Domain.Entities
{
    [Obsolete("Delete after creating the authorization server")]
    /// <summary>
    /// 
    /// </summary>
    public class UserEntity
    {
        /// <summary>
        /// Логин.
        /// </summary>
        public required string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Почта.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// id роли.
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// Роль.
        /// </summary>
        public virtual required RoleEntity Role { get; set; }
    }
}

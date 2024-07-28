namespace CyberTech.Domain.Models.Handbooks
{
    /// <summary>
    /// 
    /// </summary>
    public class User
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
        public virtual required Role Role { get; set; }
    }
}

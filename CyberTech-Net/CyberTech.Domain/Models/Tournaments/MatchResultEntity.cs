using CyberTech.Domain.Interfaces;
using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.Domain.Models.Tournaments
{
    /// <summary>
    /// Результат матча
    /// </summary>
    public class MatchResultEntity : IEntity<Guid>
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id встречи.
        /// </summary>
        public Guid MatchId { get; set; }

        /// <summary>
        /// Встреча турнира.
        /// </summary>
        public virtual MatchEntity Match { get; set; }

        /// <summary>
        /// Id команды.
        /// </summary>
        public Guid TeamId { get; set; }

        /// <summary>
        /// Команда.
        /// </summary>
        public virtual TeamEntity Team { get; set; }

        /// <summary>
        /// Заработано очков.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Победа или проигрыш.
        /// </summary>
        public bool IsWin { get; set; }        
    }
}

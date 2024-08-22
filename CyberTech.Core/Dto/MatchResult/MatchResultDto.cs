using CyberTech.Core.Dto.Match;
using CyberTech.Core.Dto.Team;

namespace CyberTech.Core.Dto.MatchResult
{
    public class MatchResultDto
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; } 

        /// <summary>
        /// Встреча турнира.
        /// </summary>
        public MatchDto Match { get; set; } 

        /// <summary>
        /// Команда.
        /// </summary>
        public TeamDto Team { get; set; } 

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

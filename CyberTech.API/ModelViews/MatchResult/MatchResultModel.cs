using CyberTech.API.ModelViews.Match;
using CyberTech.API.ModelViews.Team;

namespace CyberTech.API.ModelViews.MatchResult
{
    /// <summary>
    /// Результат матча
    /// </summary>
    public class MatchResultModel
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Встреча турнира.
        /// </summary>
        public MatchModel Match { get; set; }

        /// <summary>
        /// Команда.
        /// </summary>
        public TeamModel Team { get; set; }

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

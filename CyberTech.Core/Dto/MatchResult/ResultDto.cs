using CyberTech.Core.Dto.Match;
using CyberTech.Core.Dto.Team;

namespace CyberTech.Core.Dto.MatchResult
{
    public class ResultDto(Guid id, MatchDto match, TeamDto team, int score, bool isWin)
    {

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; } = id;

        /// <summary>
        /// Встреча турнира.
        /// </summary>
        public MatchDto Match { get; set; } = match;

        /// <summary>
        /// Команда.
        /// </summary>
        public TeamDto Team { get; set; } = team;

        /// <summary>
        /// Заработано очков.
        /// </summary>
        public int Score { get; set; } = score;

        /// <summary>
        /// Победа или проигрыш.
        /// </summary>
        public bool IsWin { get; set; } = isWin;
    }
}

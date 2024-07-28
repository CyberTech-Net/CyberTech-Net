using CyberTech.API.ModelViews.Match;
using CyberTech.API.ModelViews.Team;

namespace CyberTech.API.ModelViews.MatchResult
{
    /// <summary>
    /// Результат матча
    /// </summary>
    public class ResultModel
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

        public ResultModel(Guid id, MatchModel match, TeamModel team, int score, bool isWin)
        {
            Id = id;
            Match = match;
            Team = team;
            Score = score;
            IsWin = isWin;
        }

        protected ResultModel()
        {
            
        }
    }
}

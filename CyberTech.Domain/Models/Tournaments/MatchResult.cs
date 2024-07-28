using CyberTech.Domain.Interfaces;
using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.Domain.Models.Tournaments
{
    /// <summary>
    /// Результат матча
    /// </summary>
    public class MatchResult : IEntity<Guid>
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
        public Match Match { get; set; }

        /// <summary>
        /// Id команды.
        /// </summary>
        public Guid TeamId { get; set; }

        /// <summary>
        /// Команда.
        /// </summary>
        public Team Team { get; set; }

        /// <summary>
        /// Заработано очков.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Победа или проигрыш.
        /// </summary>
        public bool IsWin { get; set; }

        public MatchResult(Guid matchId, Guid teamId, int score, bool isWin)
        {
            MatchId = matchId;
            TeamId = teamId;
            Score = score;
            IsWin = isWin;
        }

        protected MatchResult()
        {
            
        }

        public static MatchResult CreateNewInstanse(Guid matchId, Guid teamId, int score, bool isWin)
        {
            return new MatchResult(
                matchId: matchId,
                teamId: teamId,
                score: score,
                isWin: isWin);
        }

        public void Update(int score, bool isWin)
        {
            Score = score;
            IsWin = isWin;
        }
    }
}

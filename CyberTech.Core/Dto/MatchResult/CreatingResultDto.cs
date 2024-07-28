namespace CyberTech.Core.Dto.MatchResult
{
    public class CreatingResultDto(Guid matchId, Guid teamId, int score, bool isWin)
    {

        /// <summary>
        /// Id встречи.
        /// </summary>
        public Guid MatchId { get; set; } = matchId;

        /// <summary>
        /// Id команды.
        /// </summary>
        public Guid TeamId { get; set; } = teamId;

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

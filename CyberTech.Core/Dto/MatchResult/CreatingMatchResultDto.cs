namespace CyberTech.Core.Dto.MatchResult
{
    public class CreatingMatchResultDto
    {
        /// <summary>
        /// Id встречи.
        /// </summary>
        public Guid MatchId { get; set; } 

        /// <summary>
        /// Id команды.
        /// </summary>
        public Guid TeamId { get; set; } 

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

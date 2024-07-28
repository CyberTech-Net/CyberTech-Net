namespace CyberTech.Core.Dto.MatchResult
{
    public class UpdatingResultDto(Guid id, int score, bool isWin)
    {

        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; } = id;

        /// <summary>
        /// Заработано командой очков
        /// </summary>
        public int Score { get; set; } = score;

        /// <summary>
        /// Победаила ли команда
        /// </summary>
        public bool IsWin { get; set; } = isWin;
    }
}

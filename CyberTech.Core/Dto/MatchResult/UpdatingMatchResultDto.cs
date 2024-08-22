namespace CyberTech.Core.Dto.MatchResult
{
    public class UpdatingMatchResultDto
    {
        /// <summary>
        /// Заработано командой очков
        /// </summary>
        public int Score { get; set; } 

        /// <summary>
        /// Победаила ли команда
        /// </summary>
        public bool IsWin { get; set; } 
    }
}

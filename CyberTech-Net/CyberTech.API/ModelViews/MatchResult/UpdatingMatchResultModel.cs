namespace CyberTech.API.ModelViews.MatchResult
{
    public class UpdatingMatchResultModel
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

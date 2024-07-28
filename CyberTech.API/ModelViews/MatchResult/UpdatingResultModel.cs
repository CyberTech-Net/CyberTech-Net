namespace CyberTech.API.ModelViews.MatchResult
{
    public class UpdatingResultModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Заработано командой очков
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Победаила ли команда
        /// </summary>
        public bool IsWin { get; set; }

        public UpdatingResultModel(Guid id, int score, bool isWin)
        {
            Id = id;
            Score = score;
            IsWin = isWin;
        }

        protected UpdatingResultModel()
        {
            
        }
    }
}

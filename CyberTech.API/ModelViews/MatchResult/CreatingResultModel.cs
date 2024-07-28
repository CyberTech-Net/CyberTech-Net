namespace CyberTech.API.ModelViews.MatchResult
{
    public class CreatingResultModel
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

        public CreatingResultModel(Guid matchId, Guid teamId, int score, bool isWin)
        {
            MatchId = matchId;
            TeamId = teamId;
            Score = score;
            IsWin = isWin;
        }

        public CreatingResultModel()
        {
            
        }
    }
}

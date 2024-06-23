namespace CyberTech.Domain.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class TournamentMeetTeamEntity : IEntity<Guid>
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id встречи.
        /// </summary>
        public Guid TournamentMeetId { get; set; }

        /// <summary>
        /// Встреча турнира.
        /// </summary>
        public virtual TournamentMeetEntity TournamentMeet { get; set; }

        /// <summary>
        /// Id команды.
        /// </summary>
        public Guid TeamId { get; set; }

        /// <summary>
        /// Команда.
        /// </summary>
        public virtual TeamEntity Team { get; set; }

        /// <summary>
        /// Заработано очков.
        /// </summary>
        public int ScoreTeam { get; set; }

        /// <summary>
        /// Заработано средств.
        /// </summary>
        public decimal EarndTeam { get; set; }

        /// <summary>
        /// Рейтинг.       
        /// </summary>
        public int RatingTeam { get; set; }

        /// <summary>
        /// Победа или проигрыш.
        /// </summary>
        public bool Win { get; set; }
    }
}
    
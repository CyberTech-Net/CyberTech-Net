namespace CyberTech.Domain.Entities
{
    public class TeamEntity : IEntity<Guid>
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Наименование.
        /// </summary>
        public string TitleTeam { get; set; }
        
        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTime Founded { get; set; }
        
        /// <summary>
        /// Игроки.
        /// </summary>
        public virtual List<TeamPlayerEntity> TeamPlayers { get; set; }     

        /// <summary>
        /// Результаты встречи.
        /// </summary>
        public virtual List<TournamentMeetTeamEntity> TournamentMeetTeams { get; set; }
    }
}

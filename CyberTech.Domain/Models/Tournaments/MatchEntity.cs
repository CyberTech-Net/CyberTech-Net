using CyberTech.Domain.Interfaces;
using CyberTech.Domain.Models.Handbooks;
using System.Drawing;

namespace CyberTech.Domain.Models.Tournaments
{
    /// <summary>
    /// Встреча турнира.
    /// </summary>
    public class MatchEntity : IEntity<Guid>
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id турнира.
        /// </summary>
        public Guid TournamentId { get; set; }

        /// <summary>
        /// Id команды.
        /// </summary>
        public Guid FirstTeamId { get; set; }

        /// <summary>
        /// Id команды.
        /// </summary>
        public Guid SecondTeamId { get; set; }

        /// <summary>
        /// Турнир.
        /// </summary>
        public virtual TournamentEntity Tournament { get; set; }

        /// <summary>
        /// Дата встречи.
        /// </summary>
        public DateTime StartDateTime { get; set; }

        public virtual TeamEntity FirstTeam { get; set; }

        public virtual TeamEntity SecondTeam { get; set; }

        /// <summary>
        /// Результаты встречи.
        /// </summary>
        public virtual List<MatchResultEntity> MatchResults { get; set; }       
    }
}

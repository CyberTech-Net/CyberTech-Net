using CyberTech.Domain.Interfaces;
using System.Drawing;

namespace CyberTech.Domain.Models.Tournaments
{
    /// <summary>
    /// Встреча турнира.
    /// </summary>
    public class Match : IEntity<Guid>
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
        public Guid FirtstTeamId { get; set; }

        /// <summary>
        /// Id команды.
        /// </summary>
        public Guid SecondTeamId { get; set; }

        /// <summary>
        /// Турнир.
        /// </summary>
        public Tournament Tournament { get; set; }

        /// <summary>
        /// Дата встречи.
        /// </summary>
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// Результаты встречи.
        /// </summary>
        public List<MatchResult> MatchResults { get; set; }

        public Match(Guid tournamentId, DateTime startDateTime, Guid firtstTeamId, Guid secondTeamId)
        {
            TournamentId = tournamentId;
            StartDateTime = startDateTime;
            FirtstTeamId = firtstTeamId;
            SecondTeamId = secondTeamId;
        }

        protected Match()
        {
            
        }

        public void Update(Guid tournamentId, DateTime startDateTime)
        {
            TournamentId = tournamentId;
            StartDateTime = startDateTime;
        }

        public static Match CreateNewInstanse(Guid tournamentId, DateTime startDateTime, Guid firtstTeamId, Guid secondTeamId)
        {
            return new Match(
                tournamentId: tournamentId,
                startDateTime: startDateTime,
                firtstTeamId: firtstTeamId,
                secondTeamId:secondTeamId);
        }
    }
}

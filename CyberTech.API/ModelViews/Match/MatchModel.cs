using CyberTech.API.ModelViews.Team;
using CyberTech.API.ModelViews.Tournament;

namespace CyberTech.API.ModelViews.Match
{
    /// <summary>
    /// Данные о турирной встрече
    /// </summary>
    public class MatchModel
    {
        /// <summary>
        /// Идентификатор встречи
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор турнира
        /// </summary>
        public TournamentModel Tournament { get; set; }

        /// <summary>
        /// Дата и время начала встречи
        /// </summary>
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// Id команды.
        /// </summary>
        public TeamModel FirstTeam { get; set; }

        /// <summary>
        /// Id команды.
        /// </summary>
        public TeamModel SecondTeam { get; set; }
    }
}

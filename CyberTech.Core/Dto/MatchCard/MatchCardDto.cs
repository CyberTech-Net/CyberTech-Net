using CyberTech.Core.Dto.Team;
using CyberTech.Core.Dto.Tournament;


namespace CyberTech.Core.Dto.MatchCard
{
    public class MatchCardDto
    {
        public Guid Id { get; set; }
        public TeamDto FirstTeam { get; set; }
        public TeamDto SecondTeam { get; set; }
        public string FirstTeamResult { get; set; }
        public TournamentDto Tournament { get; set; }
        public string SecondTeamResult { get; set; }
        public int FirstTeamScore { get; set; }
        public int SecondTeamScore { get; set; }
        public DateTime StartDateTime { get; set; }
    }
}

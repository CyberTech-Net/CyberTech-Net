using CyberTech.Core.Dto.Team;
using CyberTech.Core.Dto.Tournament;

namespace CyberTech.Core.Dto.Match
{
    public class MatchDto
    {
        public Guid Id { get; set; } 
        public DateTime StartDateTime { get; set; } 
        public TournamentDto Tournament { get; set; }
        public TeamDto FirstTeam { get; set; } 
        public TeamDto SecondTeam { get; set; } 
    }
}

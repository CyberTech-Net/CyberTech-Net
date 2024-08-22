using CyberTech.Core.Dto.Player;
using CyberTech.Core.Dto.Team;

namespace CyberTech.Core.Dto.TeamPlayer
{
    public class TeamPlayerDto
    {
        public Guid Id { get; set; }
        public TeamDto Team { get; set; }
        public PlayerDto Player { get; set; }        
        public int Year1 { get; set; }
        public int? Year2 { get; set; }
    }
}

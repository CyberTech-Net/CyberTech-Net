using CyberTech.Core.Dto.Player;
using CyberTech.Core.Dto.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberTech.Core.Dto.TeamRating
{
    public class TeamRatingDto
    {
        public Guid Id { get; set; }
        public string TeamNaim { get; set; }
        public int Score { get; set; }
        public int WinCount { get; set; }
        public int LoseCount { get; set; }
        public int MatchCount { get; set; }
        public DateTime? LastMatch { get; set; }
        public DateTime? FutureMatch { get; set; }
        public string ImageId { get; set; }
    }
}

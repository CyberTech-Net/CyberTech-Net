using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberTech.Core.Dto.TeamPlayer
{
    public class TeamPlayerDto
    {
        public Guid Id { get; set; }
        public Guid TeamId { get; set; }
        public string TitleTeam { get; set; }
        public Guid PlayerId { get; set; }
        public string FIO { get; set; }
        public int Year1 { get; set; }
        public int? Year2 { get; set; }
    }
}

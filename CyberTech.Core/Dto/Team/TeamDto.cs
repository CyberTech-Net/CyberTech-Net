using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberTech.Core.Dto.Team
{
    public class TeamDto
    {
        public Guid Id { get; set; }
        public string TitleTeam { get; set; }
        public DateTime Founded { get; set; }
    }
}

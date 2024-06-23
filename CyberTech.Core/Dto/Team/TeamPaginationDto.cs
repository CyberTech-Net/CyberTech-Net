using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberTech.Core.Dto.Team
{
    public class TeamPaginationDto
    {
        public string TitleTeam { get; set; }
        public DateTime Founded { get; set; }

        public int ItemsPerPage { get; set; }

        public int Page { get; set; }
    }
}

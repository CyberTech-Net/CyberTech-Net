using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberTech.Core.Dto.Player
{
    public class PlayerPaginationDto
    {
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public int ItemsPerPage { get; set; }
        public int Page { get; set; }
    }
}

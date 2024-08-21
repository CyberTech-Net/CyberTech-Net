using CyberTech.Core.Dto.Country;
using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.Core.Dto.Player
{
    public class PlayerPaginationDto
    {
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime BirthDate { get; set; }
        public CountryDto Country { get; set; }
        public string ImageId { get; set; }
        public int ItemsPerPage { get; set; }
        public int Page { get; set; }
    }
}

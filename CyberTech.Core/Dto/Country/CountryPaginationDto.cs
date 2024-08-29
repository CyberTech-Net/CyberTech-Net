namespace CyberTech.Core.Dto.Country
{
    public class CountryPaginationDto
    {
        public string TitleCountry { get; set; }
        public string ImageId { get; set; }

        public int ItemsPerPage { get; set; }

        public int Page { get; set; }
    }
}

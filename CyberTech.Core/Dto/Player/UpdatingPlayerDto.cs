namespace CyberTech.Core.Dto.Player
{
    public class UpdatingPlayerDto
    {
        public Guid CountryId { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImageId { get; set; }
    }
}

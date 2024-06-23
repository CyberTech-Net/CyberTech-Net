namespace CyberTech.API.ModelViews.Player
{
    public class PlayerModel
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string BirthDate { get; set; }
        public string Country { get; set; }
    }
}

namespace CyberTech.API.ModelViews.Player
{
    public class PlayerPaginationModel
    {
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string BirthDate { get; set; }
        public string Country { get; set; }
        public int ItemsPerPage { get; set; }
        public int Page { get; set; }
    }
}

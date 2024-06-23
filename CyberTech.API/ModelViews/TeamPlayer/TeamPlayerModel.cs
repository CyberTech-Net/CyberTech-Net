namespace CyberTech.API.ModelViews.TeamPlayer
{
    public class TeamPlayerModel
    {
        public Guid Id { get; set; }
        public Guid TeamId { get; set; }
        public string TitleTeam { get; set; }
        public Guid PlayerId { get; set; }
        public string FIO { get; set; }
        public string Year1 { get; set; }
        public string Year2 { get; set; }
    }
}

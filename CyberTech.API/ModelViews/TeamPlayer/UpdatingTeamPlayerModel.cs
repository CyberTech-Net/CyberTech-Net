namespace CyberTech.API.ModelViews.TeamPlayer
{
    public class UpdatingTeamPlayerModel
    {
        public Guid TeamId { get; set; }
        public Guid PlayerId { get; set; }
        public string Year1 { get; set; }
        public string Year2 { get; set; }
    }
}

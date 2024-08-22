namespace CyberTech.API.ModelViews.Team
{
    public class TeamPaginationModel
    {
        public string TitleTeam { get; set; }
        public string Founded { get; set; }
        public int ItemsPerPage { get; set; }
        public int Page { get; set; }
    }
}

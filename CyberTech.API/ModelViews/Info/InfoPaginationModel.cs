namespace CyberTech.API.ModelViews.News
{
    public class InfoPaginationModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public int ItemsPerPage { get; set; }
        public int Page { get; set; }
        public string ImageId { get; set; }

        public InfoPaginationModel(string title, string text, string date, string imageId, int itemsPerPage, int page)
        {
            Title = title;
            Text = text;
            Date = date;
            ImageId = imageId;
            ItemsPerPage = itemsPerPage;
            Page = page;
        }

        protected InfoPaginationModel()
        {

        }
    }
}

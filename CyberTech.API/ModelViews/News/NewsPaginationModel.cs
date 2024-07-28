namespace CyberTech.API.ModelViews.News
{
    public class NewsPaginationModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public int ItemsPerPage { get; set; }
        public int Page { get; set; }

        public NewsPaginationModel(string title, string text, string date, int itemsPerPage, int page)
        {
            Title = title;
            Text = text;
            Date = date;
            ItemsPerPage = itemsPerPage;
            Page = page;
        }

        protected NewsPaginationModel()
        {

        }
    }
}

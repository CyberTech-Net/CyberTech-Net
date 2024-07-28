namespace CyberTech.API.ModelViews.News
{
    public class NewsModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public NewsModel(Guid id, string title, string text, DateTime date)
        {
            Id = id;
            Title = title;
            Text = text;
            Date = date;
        }

        protected NewsModel()
        {

        }
    }
}

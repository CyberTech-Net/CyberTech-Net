namespace CyberTech.API.ModelViews.News
{
    public class InfoModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string ImageId { get; set; }

        public InfoModel(Guid id, string title, string text, DateTime date, string imageId)
        {
            Id = id;
            Title = title;
            Text = text;
            Date = date;
            ImageId = imageId;
        }

        protected InfoModel()
        {

        }
    }
}

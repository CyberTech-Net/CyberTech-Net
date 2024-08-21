namespace CyberTech.API.ModelViews.News
{
    public class CreatingInfoModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string ImageId { get; set; }

        public CreatingInfoModel(string title, string text, DateTime date, string imageId)
        {
            Title = title;
            Text = text;
            Date = date;
            ImageId = imageId;
        }
        protected CreatingInfoModel()
        {

        }
    }
}

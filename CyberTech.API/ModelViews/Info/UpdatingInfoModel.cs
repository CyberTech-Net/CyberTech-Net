namespace CyberTech.API.ModelViews.News
{
    public class UpdatingInfoModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string ImageId { get; set; }

        public UpdatingInfoModel(string title, string text, DateTime date, string imageId)
        {
            Title = title;
            Text = text;
            Date = date;
            ImageId = imageId;
        }

        protected UpdatingInfoModel()
        {

        }
    }
}

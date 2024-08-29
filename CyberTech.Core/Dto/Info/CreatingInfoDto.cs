namespace CyberTech.Core.Dto.News
{
    public class CreatingInfoDto(string title, string text, DateTime date, string imageId)
    {
        public string Title { get; set; } = title;
        public string Text { get; set; } = text;
        public DateTime Date { get; set; } = date;
        public string ImageId { get; set; } = imageId;
    }
}

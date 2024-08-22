namespace CyberTech.Core.Dto.News
{
    public class InfoDto(Guid id, string title, string text, DateTime date, string imageId)
    {
        public Guid Id { get; set; } = id;
        public string Title { get; set; } = title;
        public string Text { get; set; } = text;
        public DateTime Date { get; set; } = date;
        public string ImageId { get; set; } = imageId;
    }
}

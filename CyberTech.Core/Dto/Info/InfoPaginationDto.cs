using static System.Net.Mime.MediaTypeNames;

namespace CyberTech.Core.Dto.News
{
    public class InfoPaginationDto(string title, string text, DateTime date, int itemsPerPage, int page, string imageId)
    {
        public string Title { get; set; } = title;
        public string Text { get; set; } = text;
        public string ImageId { get; set; } = imageId;
        public DateTime Date { get; set; } = date;
        public int ItemsPerPage { get; set; } = itemsPerPage;
        public int Page { get; set; } = page;
    }
}

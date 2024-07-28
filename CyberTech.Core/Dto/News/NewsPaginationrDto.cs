namespace CyberTech.Core.Dto.News
{
    public class NewsPaginationrDto(string title, string text, DateTime date, int itemsPerPage, int page)
    {
        public string Title { get; set; } = title;
        public string Text { get; set; } = text;
        public DateTime Date { get; set; } = date;
        public int ItemsPerPage { get; set; } = itemsPerPage;
        public int Page { get; set; } = page;
    }
}

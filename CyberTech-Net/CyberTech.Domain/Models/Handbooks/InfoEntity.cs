using CyberTech.Domain.Interfaces;

namespace CyberTech.Domain.Models.Handbooks
{
    /// <summary>
    /// Новость.
    /// </summary>
    public class InfoEntity : IEntity<Guid>
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Заголовок новости.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Текст.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Дата.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Картинка/фото.
        /// </summary>
        public string ImageId { get; set; }

        /// <summary>
        /// Видео.
        /// </summary>
        public string? MongoInfoVideo { get; set; }

        public InfoEntity(string title, string text, DateTime date, string imageId)
        {
            Title = title;
            Text = text;
            Date = date;
            ImageId = imageId;
        }

        protected InfoEntity()
        {
            
        }

        public void Update(string title, string text, DateTime date, string imageId)
        {
            Title = title;
            Text = text;
            Date = date;
            ImageId = imageId;
        }

        public static InfoEntity CreateNewInstanse(string title, string text, DateTime date, string imageId)
        {
            return new InfoEntity(
                title: title,
                text: text,
                date: date,
                imageId: imageId);
        }
    }
}

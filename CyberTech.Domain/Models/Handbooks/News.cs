using CyberTech.Domain.Interfaces;
using System.Data;

namespace CyberTech.Domain.Models.Handbooks
{
    /// <summary>
    /// Новость.
    /// </summary>
    public class News : IEntity<Guid>
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
        public int? MongoInfoVideo { get; set; }

        public News(string title, string text, DateTime date, string imageId)
        {
            Title = title;
            Text = text;
            Date = date;
            ImageId = imageId;
        }

        protected News()
        {
            
        }

        public void Update(string title, string text, DateTime date, string imageId)
        {
            Title = title;
            Text = text;
            Date = date;
            ImageId = imageId;
        }

        public static News CreateNewInstanse(string title, string text, DateTime date, string imageId)
        {
            return new News(
                title: title,
                text: text,
                date: date,
                imageId: imageId);
        }


    }
}

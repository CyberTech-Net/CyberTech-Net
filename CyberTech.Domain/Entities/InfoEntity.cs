﻿namespace CyberTech.Domain.Entities
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
        public string TitleInfo { get; set; } = string.Empty;

        /// <summary>
        /// Текст.
        /// </summary>
        public string TextInfo { get; set; } = string.Empty;

        /// <summary>
        /// Дата.
        /// </summary>
        public DateTime DataInfo { get; set; }

        /// <summary>
        /// Турниры.
        /// </summary>
        public virtual List<InfoImageEntity>? InfoImages { get; set; }
    }
}

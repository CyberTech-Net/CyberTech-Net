namespace CyberTech.Domain.Entities
{
    public class InfoImageEntity : IEntity<Guid>
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id вида игры.
        /// </summary>
        public Guid InfoId { get; set; }

        /// <summary>
        /// Новость.
        /// </summary>
        public virtual InfoEntity Info { get; set; }

        /// <summary>
        /// Картинки для новости.
        /// </summary>
        public string ImageId { get; set; }
    }
}

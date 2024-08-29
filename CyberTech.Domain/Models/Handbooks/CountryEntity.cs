using CyberTech.Domain.Interfaces;

namespace CyberTech.Domain.Models.Handbooks
{
    /// <summary>
    /// Страна.
    /// </summary>
    public class CountryEntity : IEntity<Guid>
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string TitleCountry { get; set; } = string.Empty;

        /// <summary>
        /// Картинка с флагом страны.
        /// </summary>
        public string ImageId { get; set; } = string.Empty;

        /// <summary>
        /// Игроки.
        /// </summary>
        public virtual List<PlayerEntity> Players { get; set; }
    }
}

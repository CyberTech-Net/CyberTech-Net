using CyberTech.Domain.Interfaces;

namespace CyberTech.Domain.Models.Handbooks
{

    /// <summary>
    /// Страна.
    /// </summary>
    public class Country : IEntity<Guid>
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
        public int? MongoCountryPic { get; set; }

        /// <summary>
        /// Игроки.
        /// </summary>
        public virtual List<Player> Players { get; set; }
    }
}

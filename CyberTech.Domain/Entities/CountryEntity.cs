namespace CyberTech.Domain.Entities
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
        public int? MongoCountryPic { get; set; }

        /// <summary>
        /// Игроки.
        /// </summary>
        public virtual List<PlayerEntity> Players { get; set; }
    }
}

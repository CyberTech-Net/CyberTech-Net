namespace CyberTech.API.ModelViews.Country
{
    /// <summary>
    /// Модель создаваемой страны.
    /// </summary>
    public class CreatingCountryModel
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        public string TitleCountry { get; set; }
        /// <summary>
        /// Картинка.
        /// </summary>
        public string ImageId { get; set; } = string.Empty;
    }
}

namespace CyberTech.API.ModelViews.Country
{
    public class CountryModel
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование.
        /// </summary>
        public string TitleCountry { get; set; }
        /// <summary>
        /// Картинка.
        /// </summary>
        public string ImageId { get; set; }
    }
}

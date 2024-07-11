namespace CyberTech.API.ModelViews.GameType
{
    /// <summary>
    /// Модель создаваемой игры.
    /// </summary>
    public class CreatingGameTypeModel
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        public string TitleGame { get; set; }

        /// <summary>
        /// Картинка.
        /// </summary>
        public string ImageId { get; set; } = string.Empty;
    }
}

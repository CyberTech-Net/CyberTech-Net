namespace CyberTech.API.ModelViews.GameType
{
    /// <summary>
    /// Модель редактируемой страны.
    /// </summary>
    public class UpdatingGameTypeModel
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        public string TitleGame { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Жанр игры.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Картинка.
        /// </summary>
        public string ImageId { get; set; }
    }
}

namespace CyberTech.API.ModelViews.GameType
{
    public class GameTypeModel
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string TitleGame { get; set; }

        /// <summary>
        /// Картинка.
        /// </summary>
        public string ImageId { get; set; }
    }
}

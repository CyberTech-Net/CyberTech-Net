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
        /// Описание.
        /// </summary>
        public string Description { get; set; }        
    }
}

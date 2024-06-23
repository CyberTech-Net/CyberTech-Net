namespace CyberTech.Domain.Entities
{
    /// <summary>
    /// Игрок.
    /// </summary>
    public class PlayerEntity : IEntity<Guid>
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id страны.
        /// </summary>
        public Guid CountryId { get; set; }

        /// <summary>
        /// Никнейм.
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Фото.
        /// </summary>
        public int? MongoPlayerPic { get; set; }

        /// <summary>
        /// Страна.
        /// </summary>
        public virtual CountryEntity Country { get; set; }

        /// <summary>
        /// Команды игрока.
        /// </summary>
        public virtual List<TeamPlayerEntity> TeamPlayers { get; set; }
    }
}

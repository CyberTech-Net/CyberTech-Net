using CyberTech.Domain.Interfaces;

namespace CyberTech.Domain.Models.Handbooks
{
    /// <summary>
    /// Игрок.
    /// </summary>
    public class Player : IEntity<Guid>
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
        public virtual Country Country { get; set; }

        /// <summary>
        /// Команды игрока.
        /// </summary>
        public virtual List<TeamPlayer> TeamPlayers { get; set; }
    }
}

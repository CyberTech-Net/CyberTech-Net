namespace CyberTech.Settings.RabbitMqQueueSettings
{
    /// <summary>
    /// Настройки очереди для публикации событий о запланированной встречи
    /// </summary>
    public class MatchPlanned
    {
        public const string Section = "MatchPlanned";

        public string ExchangeType { get; set; }
        public string ExchangeName { get; set; }
        public string RoutingKey { get; set; }
        public bool Durable { get; set; }
    }
}

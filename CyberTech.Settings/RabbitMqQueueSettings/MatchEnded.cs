namespace CyberTech.Settings.RabbitMqQueueSettings
{
    /// <summary>
    /// Настройки очереди для получения событий о завершенной встречи
    /// </summary>
    public class MatchEnded
    {
        public const string Section = "MatchEnded";

        public string ExchangeName { get; set; }
        public string Type { get; set; }
        public bool Durable { get; set; }
        public bool AutoDelete { get; set; }
        public string QueueName { get; set; }
        public string RoutingKey { get; set; }
    }
}

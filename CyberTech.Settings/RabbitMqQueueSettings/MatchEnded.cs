namespace CyberTech.Settings.RabbitMqQueueSettings
{
    /// <summary>
    /// Настройки очереди для получения событий о завершенной встречи
    /// </summary>
    public class MatchEnded
    {
        public const string Section = "MatchEnded";

        public string QueueName { get; set; }
        public string ExchangeName { get; set; }
        public string RoutingKey { get; set; }
    }
}

using Cybertech.MatchApi.Settings;

namespace CyberTech.MatchApi.Settings
{
    public class AppSettings
    {
        public RmqSettings RmqSettings { get; set; }
        public RedisSettings RedisSettings { get; set; }
    }
}

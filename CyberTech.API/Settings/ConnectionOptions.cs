namespace CyberTech.API.Settings
{
    public class ConnectionOptions
    {
        public const string Section = "Connections";

        public string DBConnection { get; set; }
        public RmqSettings RmqSettings { get; set; }
    }
}

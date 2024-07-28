namespace CyberTech.API.Settings
{
    public class ConnectionOptions
    {
        public const string Section = "Connections";

        public string DBConnection { get; set; } = string.Empty;
        public RmqOptions? Rmq { get; set; } = new ();
    }
}

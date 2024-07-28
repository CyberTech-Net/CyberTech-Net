namespace CyberTech.API.Settings
{
    public class RmqOptions
    {
        public const string Section = "RmqSettings";
        public string Host { get; set; } = string.Empty;
        public string VHost { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}

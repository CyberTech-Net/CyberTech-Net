namespace CyberTech.Core.IServices
{
    public interface IRabbitMqService
    {
        public void SendMessage(object obj);
    }
}

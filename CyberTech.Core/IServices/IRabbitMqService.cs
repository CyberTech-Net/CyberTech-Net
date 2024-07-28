using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberTech.Core.IServices
{
    public interface IRabbitMqService
    {
        public void SendMessage(object obj);
        public void SendMessage(string message);
    }
}

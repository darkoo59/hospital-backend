using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Settings
{
    public class RabbitMQNotificationSettings
    {
        public string HostName { get; set; }
        public string QueueName { get; set; }
    }
}

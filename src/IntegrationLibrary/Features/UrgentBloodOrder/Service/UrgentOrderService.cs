using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudentService;

namespace IntegrationLibrary.Features.UrgentBloodOrder.Service
{
    public class UrgentOrderService : IUrgentOrderService
    {
        private Channel _channel { get; set; }
        public UrgentOrderService()
        {
            _channel = new Channel("localhost", 6565, ChannelCredentials.Insecure);
        }

        public StudentResponse InvokeUrgentOrder()
        {
            StudentServiceClient client = new StudentServiceClient(_channel);
            StudentRequest request = new StudentRequest();
            
            return client.GetStudent(request);
        }

        
    }
}

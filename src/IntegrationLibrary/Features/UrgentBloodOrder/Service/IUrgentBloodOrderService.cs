using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.UrgentBloodOrder.Service
{
    public interface IUrgentBloodOrderService
    {
        UrgentResponse InvokeUrgentOrder(int bloodType, float quantity, string server);
    }
}

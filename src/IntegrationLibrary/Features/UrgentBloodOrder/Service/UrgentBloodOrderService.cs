using Grpc.Core;
using IntegrationLibrary.Features.UrgentBloodOrder.DTO;
using IntegrationLibrary.HospitalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UrgentOrderService;

namespace IntegrationLibrary.Features.UrgentBloodOrder.Service
{
    public class UrgentBloodOrderService : IUrgentBloodOrderService
    {
        private readonly IHospitalService _hospitalService;
        private Channel _channel { get; set; }
        public UrgentBloodOrderService(IHospitalService hospitalRepository)
        {
            this._hospitalService = hospitalRepository;
        }

        public UrgentResponse InvokeUrgentOrder(int bloodType, float quantity, string server)
        {
            //Int32 port = Int32.Parse(server.Substring(server.Length - 4)); Kada bude integrisano i za ostale isa projekte

            _channel = new Channel("localhost", 6565, ChannelCredentials.Insecure);


            UrgentOrderServiceClient client = new UrgentOrderServiceClient(_channel);
            UrgentRequest request = new UrgentRequest();
            request.BloodType = bloodType;
            request.Quantity = quantity;

            UrgentResponse response = client.InvokeUrgentOrder(request);
            
            if (response.HasEnough)
            {
                _hospitalService.UpdateBloodQuantity(bloodType, quantity);
                Console.WriteLine("New blood has arrived.");
            } else
            {
                Console.WriteLine("No new blood has arrived.");
            }
            return response;
        }

        
    }
}

using IntegrationLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service
{
    public class BloodTypeService : IBloodTypeService
    {

        public BloodTypeService() {}
        public bool CheckBloodTypeAvailability(BloodTypesEnum bloodType, string apiKey, float bloodQuantity)
        {
            Console.WriteLine("Blood type: " + bloodType);
            Console.WriteLine("Api key: " + apiKey);
            Console.WriteLine("Blood quantity: " + bloodQuantity);
            return true;
        }
    }
}

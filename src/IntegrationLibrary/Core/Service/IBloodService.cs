using IntegrationLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service
{
    public interface IBloodService
    {
        Task<bool> CheckBloodTypeAvailability(BloodTypesEnum bloodType, string apiKey, float bloodQuantity, string Email);
    }
}

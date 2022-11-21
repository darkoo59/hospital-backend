using IntegrationLibrary.Features.Blood.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.Blood.Service
{
    public interface IBloodService
    {
        Task<bool> CheckBloodTypeAvailability(BloodType bloodType, string apiKey, float bloodQuantity, string Email);
    }
}

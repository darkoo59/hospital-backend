using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.MonthlyBloodSubscription.DTO
{
    public class CreateSubscriptionDTO
    {
        public int bloodBankId { get; set; }
        public double QuantityInLiters { get; set; }
        public int BloodType { get; set; }
    }
}

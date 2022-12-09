using IntegrationLibrary.Features.Blood.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.MonthlyBloodSubscription.DTO
{
    public class SubscribedBbDTO
    {
        public int Id { get; set; }
        public string AppName { get; set; }
        public int BloodBankId { get; set; }
        public string BloodType { get; set; }
        public double QuantityInLiters { get; set; }
        public DateTime StartDate { get; set; }
    }
}

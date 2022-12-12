using IntegrationLibrary.Features.Blood.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.MonthlyBloodSubscription.DTO
{
    public class SendBloodToHospitalDTO
    {
        public string BloodType { get; set; }
        public double QuantityInLiters { get; set; }
    }
}

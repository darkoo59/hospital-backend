using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.MonthlyBloodSubscription.DTO
{
    public class SendDetailsToBbDTO
    {
        public string hospitalName { get; set; }
        public string email { get; set; }
        public string server { get; set; }
        public string bloodType { get; set; }
        public double quantity { get; set; }
    }
}

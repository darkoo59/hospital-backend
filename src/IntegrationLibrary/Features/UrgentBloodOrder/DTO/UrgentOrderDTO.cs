using IntegrationLibrary.Features.Blood.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.UrgentBloodOrder.DTO
{
    public class UrgentOrderDTO
    {
        public int BloodType { get; set; }
        public float Quantity { get; set; }
        public string Server { get; set; }

    
    }
}

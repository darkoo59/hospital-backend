using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class BloodTherapyDTO
    {
        public int BloodTherapyId { get; set; }
        public string BloodType { get; set; }
        public double QuantityInLiters { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}

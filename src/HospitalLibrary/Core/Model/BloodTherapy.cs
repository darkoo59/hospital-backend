using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class BloodTherapy
    {
        public int BloodTherapyId { get; set; }
        public BloodType BloodType { get; set; }
        public double QuantityInLiters { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}

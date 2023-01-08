using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class TenderRequirement
    {
        public int Id { get; set; }
        public BloodType Type { get; set; }
        public double Amount { get; set; }
      
    }
}

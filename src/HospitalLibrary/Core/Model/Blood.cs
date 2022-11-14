using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Blood
    {
        
        public int BloodId { get; set; }
        [Required]
        public BloodType BloodType { get; set; }
        public double QuantityInLiters { get; set; }


    }
}

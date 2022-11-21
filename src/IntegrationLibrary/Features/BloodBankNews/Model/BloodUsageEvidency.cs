using IntegrationLibrary.Features.Blood.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class BloodUsageEvidency
    {
        public int BloodUsageEvidencyId { get; set; }
        [Required]

        public BloodType BloodType { get; set; }
        public double QuantityUsedInMililiters { get; set; }
        public string ReasonForUsage { get; set; }
        public DateTime DateOfUsage { get; set; }
        public int DoctorId { get; set; }
    }
}

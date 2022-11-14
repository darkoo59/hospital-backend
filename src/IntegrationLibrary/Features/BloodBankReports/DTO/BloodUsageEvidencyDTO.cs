using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.BloodBankReports.DTO
{
    public class BloodUsageEvidencyDTO
    {
        public int BloodUsageEvidencyId { get; set; }
        public string BloodType { get; set; }
        public double QuantityUsedInMililiters { get; set; }
        public string ReasonForUsage { get; set; }
        public DateTime DateOfUsage { get; set; }
        public int DoctorId { get; set; }

        public BloodUsageEvidencyDTO(int bloodUsageEvidencyId, string bloodType, double quantityUsedInMililiters, string reasonForUsage, DateTime dateOfUsage, int doctorId)
        {
            BloodUsageEvidencyId = bloodUsageEvidencyId;
            BloodType = bloodType;
            QuantityUsedInMililiters = quantityUsedInMililiters;
            ReasonForUsage = reasonForUsage;
            DateOfUsage = dateOfUsage;
            DoctorId = doctorId;
        }

        public BloodUsageEvidencyDTO(int bloodUsageEvidencyId, string bloodType, double quantityUsedInMililiters, string reasonForUsage, int doctorId)
        {
            BloodUsageEvidencyId = bloodUsageEvidencyId;
            BloodType = bloodType;
            QuantityUsedInMililiters = quantityUsedInMililiters;
            ReasonForUsage = reasonForUsage;
            DoctorId = doctorId;
        }

        public BloodUsageEvidencyDTO()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class BloodRequestDTO
    {
        public int BloodRequestId { get; set; }
        public string BloodType { get; set; }
        public double QuantityInLiters { get; set; }
        public string ReasonForRequest { get; set; }
        public DateTime FinalDate { get; set; }
        public int DoctorId { get; set; }

        public BloodRequestDTO()
        {
        }

        public BloodRequestDTO(int bloodRequestId, string bloodType, double quantityInLiters, string reasonForRequest, DateTime finalDate, int doctorId)
        {
            BloodRequestId = bloodRequestId;
            BloodType = bloodType;
            QuantityInLiters = quantityInLiters;
            ReasonForRequest = reasonForRequest;
            FinalDate = finalDate;
            DoctorId = doctorId;
        }
        public BloodRequestDTO(string bloodType, double quantityInLiters, string reasonForRequest, DateTime finalDate, int doctorId)
        {
            BloodType = bloodType;
            QuantityInLiters = quantityInLiters;
            ReasonForRequest = reasonForRequest;
            FinalDate = finalDate;
            DoctorId = doctorId;
        }






    }
}

using System;

namespace IntegrationLibrary.Features.BloodRequests.DTO
{
    public class BloodRequestDTO
    {
        public string BloodType { get; set; }
        public double QuantityInLiters { get; set; }
        public string ReasonForRequest { get; set; }
        public DateTime FinalDate { get; set; }
        public int DoctorId { get; set; }

        public BloodRequestDTO()
        {
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

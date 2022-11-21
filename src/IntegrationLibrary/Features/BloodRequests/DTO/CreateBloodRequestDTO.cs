using IntegrationLibrary.Features.Blood.Enums;
using System;

namespace IntegrationLibrary.Features.BloodRequests.DTO
{
    public class CreateBloodRequestDTO
    {
        public int BloodRequestId { get; set; }
        public BloodType BloodType { get; set; }
        public double QuantityInLiters { get; set; }
        public string ReasonForRequest { get; set; }
        public DateTime FinalDate { get; set; }
        public int DoctorId { get; set; }
    }
}

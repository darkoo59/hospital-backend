using IntegrationLibrary.Core.Enums;
using System;

namespace IntegrationLibrary.Features.BloodRequests.Model
{
    public class BloodRequest
    {
        public int Id { get; set; }
        public BloodType BloodType { get; set; }
        public double QuantityInLiters { get; set; }
        public string ReasonForRequest { get; set; }
        public DateTime FinalDate { get; set; }
        public int DoctorId { get; set; }
    }
}

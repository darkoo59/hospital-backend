using IntegrationLibrary.Features.Blood.Enums;
using IntegrationLibrary.Features.BloodRequests.Enums;
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
        public string ReasonForAdjustment { get; set; }
        public BloodRequestState State { get; set; }
        public bool Urgent { get; set; }
    }
}

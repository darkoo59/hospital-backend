using System;

namespace HospitalLibrary.Core.Model
{
    public class BloodRequest
    {
        public int BloodRequestId { get; set; }
        public BloodType BloodType { get; set; }
        public double QuantityInLiters { get; set; }
        public string ReasonForRequest { get; set; }
        public DateTime FinalDate { get; set; }
        public int DoctorId { get; set; }
    }
}

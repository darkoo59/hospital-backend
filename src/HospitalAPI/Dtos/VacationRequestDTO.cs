using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class VacationRequestDTO
    {
        public int VacationRequestId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DoctorId { get; set; }
        public bool IsApproved { get; set; }
        public string Urgency { get; set; }
        public string Reason { get; set; }

        public VacationRequestDTO() { }

        public VacationRequestDTO(int vacationRequestId, DateTime startDate, DateTime endDate, int doctorId, bool isApproved, string urgency,string reason)
        {
            VacationRequestId = vacationRequestId;
            StartDate = startDate;
            EndDate = endDate;
            DoctorId = doctorId;
            IsApproved = isApproved;
            Urgency = urgency;
            Reason = reason;
        }
    }
}

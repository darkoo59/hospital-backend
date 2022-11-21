using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class VacationRequest
    {
        public int VacationRequestId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DoctorId { get; set; }
        public VacationRequestStatus Status { get; set; }
        public string Urgency { get; set; }
        public string Reason { get; set; }
    }
}

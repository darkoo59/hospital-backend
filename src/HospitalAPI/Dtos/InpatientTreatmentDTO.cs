using HospitalAPI.Registration.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class InpatientTreatmentDTO
    {
        public int InpatientTreatmentId { get; set; }
        public int PatientId { get; set; }
        public PatientDTO Patient { get; set; }
        public string ReasonForAdmission { get; set; }
        public int RoomId { get; set; }
        public RoomDTO Room { get; set; }
        public int BedId { get; set; }
        public BedDTO Bed { get; set; }
        public DateTime DateOfAdmission { get; set; }
    }
}

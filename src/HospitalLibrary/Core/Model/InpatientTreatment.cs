using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class InpatientTreatment
    {
        public int InpatientTreatmentId { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public string ReasonForAdmission { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int BedId { get; set; }
        public Bed Bed { get; set; }
        public DateTime DateOfAdmission { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }
        public String Date { get; set; }
        public string Time { get; set; }
        public int PatientId {get; set;}
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}

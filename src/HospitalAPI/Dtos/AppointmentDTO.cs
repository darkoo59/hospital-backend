using HospitalAPI.Registration.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int? DoctorId { get; set; }
        public virtual DoctorDTO Doctor { get; set; }
        public int? PatientId { get; set; }
        public virtual PatientDTO Patient { get; set; }
        public bool IsFinished { get; set; }
    }
}

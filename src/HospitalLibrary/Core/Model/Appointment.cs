using System;

namespace HospitalLibrary.Core.Model
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime DateTime { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }


    }
}

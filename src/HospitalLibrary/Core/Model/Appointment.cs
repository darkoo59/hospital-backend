using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalLibrary.Core.Model
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        [Required]
        public DateTime Start { get; set; }
        //public int? DoctorId { get; set; }
        //[ForeignKey("DoctorId")]
        //public virtual Doctor Doctor { get; set; }
        public int? PatientId { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }


    }
}

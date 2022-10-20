using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        [Required]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        [Required]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }


    }
}

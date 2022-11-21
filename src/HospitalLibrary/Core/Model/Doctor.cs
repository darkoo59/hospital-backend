using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.Core.Model
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}

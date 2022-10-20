using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Doctor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}

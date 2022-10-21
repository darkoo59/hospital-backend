using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.Core.Model
{
    public class Patient
    {
        public int PatientId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }


    }
}

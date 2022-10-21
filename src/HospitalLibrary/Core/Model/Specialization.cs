using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.Core.Model
{
    public class Specialization
    {
        public int SpecializationId { get; set; }
        [Required]
        public string Name { get; set; }

    }
}

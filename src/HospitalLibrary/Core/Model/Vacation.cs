using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalLibrary.Core.Model
{
    public class Vacation : EntityObject
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        //[Required]
        //public int? DoctorId { get; set; }
        //[ForeignKey("DoctorId")]
        //public virtual Doctor Doctor { get; set; }
    }
}

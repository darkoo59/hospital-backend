using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HospitalLibrary.Core.Model
{
    [Index(nameof(Email), IsUnique = true)]
    public class Patient
    {
        public int PatientId { get; set; }
        [Required, NotNull]
        public string Name { get; set; }
        [Required, NotNull]
        public string Surname { get; set; }
        [Required, NotNull]
        public string Email { get; set; }
        [Required, NotNull, MinLength(3, ErrorMessage = "Password needs to be atleast 3 characters or more")]
        public string Password { get; set; }
        




    }
}

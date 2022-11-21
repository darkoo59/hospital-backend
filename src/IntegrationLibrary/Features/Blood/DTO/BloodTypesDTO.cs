using System.ComponentModel.DataAnnotations;
using IntegrationLibrary.Features.Blood.Enums;

namespace IntegrationLibrary.Features.Blood.DTO
{
    public class BloodTypesDTO
    {
        [Required]
        public BloodType BloodType { get; set; }

        [Required]
        //[MaxLength(8)]    Check ApiKey length
        public string ApiKey { get; set; }

        public float BloodQuantity { get; set; }
    }
}

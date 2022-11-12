using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IntegrationLibrary.Core.Enums;

namespace IntegrationLibrary.DTO
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

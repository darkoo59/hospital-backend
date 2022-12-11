using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class SpecializationDTO
    {
        public int SpecializationId { get; set; }
        public string Name { get; set; }
    }
}

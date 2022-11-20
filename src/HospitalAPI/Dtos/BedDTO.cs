using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class BedDTO
    {
        public int BedId { get; set; }
        public string Label { get; set; }
        public bool IsAvailable { get; set; }
    }
}

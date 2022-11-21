using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class MedicineDTO
    {
        public int MedicineId { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
    }
}

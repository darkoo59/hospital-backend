using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class MedicineTherapyDTO
    {
        public int MedicineTherapyId { get; set; }
        public int MedicineId { get; set; }
        public MedicineDTO Medicine { get; set; }
        public string Dosage { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}

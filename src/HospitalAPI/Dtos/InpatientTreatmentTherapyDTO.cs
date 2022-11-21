using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class InpatientTreatmentTherapyDTO
    {
        public int InpatientTreatmentTherapyId { get; set; }
        public int InpatientTreatmentId { get; set; }
        public InpatientTreatmentDTO InpatientTreatment { get; set; }
        public List<MedicineTherapyDTO> MedicineTherapies { get; set; }
        public List<BloodTherapyDTO> BloodTherapies { get; set; }
    }
}

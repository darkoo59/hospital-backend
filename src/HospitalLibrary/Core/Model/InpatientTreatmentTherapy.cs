using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class InpatientTreatmentTherapy
    {
        public int InpatientTreatmentTherapyId { get; set; }
        public int InpatientTreatmentId { get; set; }
        public InpatientTreatment InpatientTreatment { get; set; }
        public List<MedicineTherapy> MedicineTherapies { get; set; }
        public List<BloodTherapy> BloodTherapies { get; set; }
    }
}

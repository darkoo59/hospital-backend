using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class MedicineTherapy
    {
        public int MedicineTherapyId { get; set; }
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        public string Dosage { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

    }
}

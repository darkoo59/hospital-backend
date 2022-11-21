using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Allergen
    {
        public int AllergenId { get; set; }
        public string Name { get; set; }
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}

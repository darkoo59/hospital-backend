using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class MedicalRecord
    {
        /*public MedicalRecord(BloodType bloodType, ICollection<Allergen> allergens, int doctorsId)
        {
            BloodType = bloodType;
            Allergens = allergens;
            DoctorsId = doctorsId;
        }*/

        public int Id { get; set; }
        public BloodType BloodType { get; set; }
        public ICollection<Allergen> Allergens { get; set; }

    }
}

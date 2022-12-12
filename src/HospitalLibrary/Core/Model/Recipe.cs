using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Recipe 
    {
        public int RecipeId { get; set; }
        public List<int> MedicineIds { get; set; }
        public List<Medicine> Medicines { get; set; }
        public string WayOfUse { get; set; }
        public DateTime DateOfIssue { get; set; }

    }
}

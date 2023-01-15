using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class RecipeDTO
    {
        public int RecipeId { get; set; }
        public List<int> MedicineIds { get; set; }
        public List<MedicineDTO> Medicines { get; set; }
        public string WayOfUse { get; set; }
        public DateTime DateOfIssue { get; set; }
    }
}

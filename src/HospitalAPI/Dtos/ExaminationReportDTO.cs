using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class ExaminationReportDTO
    {
        public int ExaminationReportId { get; set; }
        public List<int> SymptomIds { get; set; }
        public List<SymptomDTO> Symptoms { get; set; }
        public string Report { get; set; }
        public List<RecipeDTO> Recipes { get; set; }
        public int AppointmentId { get; set; }
    }
}

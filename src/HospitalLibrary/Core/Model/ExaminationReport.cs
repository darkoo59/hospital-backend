using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class ExaminationReport
    {
        public int ExaminationReportId { get; set; }
        public List<Symptom> Symptoms { get; set; }
        public string Report { get; set; }
        public List<Recipe> Recipes { get; set; }

    }
}

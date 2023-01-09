using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class ExaminationReport : EntityObject
    {
        //
        public List<int> SymptomIds { get; set; }
        public List<Symptom> Symptoms { get;  }
        public string Report { get; set; }
        public List<Recipe> Recipes { get;  }
        public int AppointmentId { get; set; }

        public ExaminationReport()
        {
        }

        public ExaminationReport(List<int> symptomIds, List<Symptom> symptoms, string report, List<Recipe> recipes, int appointmentId)
        {
            if (Validate(report))
            {
                SymptomIds = symptomIds;
                Symptoms = symptoms;
                Report = report;
                Recipes = recipes;
                AppointmentId = appointmentId;
            }
            else 
            {
                throw new ArgumentException("Property report can't be empty string!");
            }
        }

        private bool Validate(string report)
        {
            return !string.IsNullOrEmpty(report);
        }
    }
}

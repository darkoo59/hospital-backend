using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class AverageNumberOfVisitsToCertainStepDTO
    {
        public double StartExamination { get; set; }
        public double SelectSymptoms { get; set; }
        public double EnterReport { get; set; }
        public double CreateRecipes { get; set; }
        public double FinishExamination { get; set; }

        public AverageNumberOfVisitsToCertainStepDTO(double startExamination, double selectSymptoms, double enterReport, double createRecipes, double finishExamination)
        {
            StartExamination = startExamination;
            SelectSymptoms = selectSymptoms;
            EnterReport = enterReport;
            CreateRecipes = createRecipes;
            FinishExamination = finishExamination;
        }
    }
}

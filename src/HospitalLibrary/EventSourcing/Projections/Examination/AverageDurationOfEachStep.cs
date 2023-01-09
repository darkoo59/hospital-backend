using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.EventSourcing.Projections.Examination
{
    public class AverageDurationOfEachStep
    {
        public double SelectSymptomsInSeconds { get; set; }
        public double EnterReportInSeconds { get; set; }
        public double CreateRecipesInSeconds { get; set; }
        public double FinishExaminationInSeconds { get; set; }

        public AverageDurationOfEachStep(double selectSymptomsInSeconds, double enterReportInSeconds, double createRecipesInSeconds, double finishExaminationInSeconds)
        {
            SelectSymptomsInSeconds = selectSymptomsInSeconds;
            EnterReportInSeconds = enterReportInSeconds;
            CreateRecipesInSeconds = createRecipesInSeconds;
            FinishExaminationInSeconds = finishExaminationInSeconds;
        }
    }
}

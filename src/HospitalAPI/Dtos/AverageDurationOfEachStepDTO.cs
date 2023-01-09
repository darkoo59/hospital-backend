using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class AverageDurationOfEachStepDTO
    {
        public double SelectSymptomsInSeconds { get; set; }
        public double EnterReportInSeconds { get; set; }
        public double CreateRecipesInSeconds { get; set; }
        public double FinishExaminationInSeconds { get; set; }

        public AverageDurationOfEachStepDTO(double selectSymptomsInSeconds, double enterReportInSeconds, double createRecipesInSeconds, double finishExaminationInSeconds)
        {
            SelectSymptomsInSeconds = selectSymptomsInSeconds;
            EnterReportInSeconds = enterReportInSeconds;
            CreateRecipesInSeconds = createRecipesInSeconds;
            FinishExaminationInSeconds = finishExaminationInSeconds;
        }
    }
}

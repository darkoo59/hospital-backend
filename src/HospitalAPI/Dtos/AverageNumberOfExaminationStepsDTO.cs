using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class AverageNumberOfExaminationStepsDTO
    {
        public double AvgNumOfSteps { get; set; }

        public AverageNumberOfExaminationStepsDTO(double avgNumOfSteps)
        {
            AvgNumOfSteps = avgNumOfSteps;
        }
    }
}

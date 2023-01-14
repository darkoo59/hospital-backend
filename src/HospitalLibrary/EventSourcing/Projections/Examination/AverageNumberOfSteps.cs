using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.EventSourcing.Projections.Examination
{
    public class AverageNumberOfSteps
    {
        public double AvgNumOfSteps { get; set; }

        public AverageNumberOfSteps(double avgNumOfSteps)
        {
            AvgNumOfSteps = avgNumOfSteps;
        }
    }
}

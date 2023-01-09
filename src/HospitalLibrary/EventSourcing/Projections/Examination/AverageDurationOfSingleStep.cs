using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.EventSourcing.Projections.Examination
{
    public class AverageDurationOfSingleStep
    {
        public double DurationInSeconds { get; set; }

        public AverageDurationOfSingleStep(double durationInSeconds)
        {
            DurationInSeconds = durationInSeconds;
        }
    }
}

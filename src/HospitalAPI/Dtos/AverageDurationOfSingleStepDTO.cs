using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class AverageDurationOfSingleStepDTO
    {
        public double DurationInSeconds { get; set; }

        public AverageDurationOfSingleStepDTO(double durationInSeconds)
        {
            DurationInSeconds = durationInSeconds;
        }
    }
}

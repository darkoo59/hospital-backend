using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class AverageDurationOfExamDTO
    {
        public double DurationInSeconds { get; set; }

        public AverageDurationOfExamDTO(double seconds)
        {
            DurationInSeconds = seconds;
        }
    }
}

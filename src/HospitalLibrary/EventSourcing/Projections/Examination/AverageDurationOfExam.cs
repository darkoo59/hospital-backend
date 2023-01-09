using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.EventSourcing.Projections.Examination
{
    public class AverageDurationOfExam
    {
        public double DurationInSeconds { get; set; }

        public AverageDurationOfExam(double seconds)
        {
            DurationInSeconds = seconds;
        }
    }
}

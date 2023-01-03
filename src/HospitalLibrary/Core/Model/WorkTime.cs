using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalLibrary.Core.Model
{
    public class WorkTime : ValueObject
    {
        public DateRange DateRange { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }

        public WorkTime(DateRange dateRange, DateTime startTime, DateTime endTime)
        {
            if (Validate(startTime, endTime))
            {
                DateRange = dateRange;
                StartTime = startTime;
                EndTime = endTime;
            }
            else
            {
                throw new ArgumentException("Passed arguments are not valid!");
            }
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DateRange;
            yield return StartTime;
            yield return EndTime;
        }

        private bool Validate(DateTime startTime, DateTime endTime)
        {
            return startTime < endTime;
        }
    }
}

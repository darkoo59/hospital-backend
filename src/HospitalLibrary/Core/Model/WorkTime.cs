using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalLibrary.Core.Model
{
    public class WorkTime : ValueObject
    {
        public DateRange DateRange { get; }
        public TimeSpan StartTime { get; }
        public TimeSpan EndTime { get; }
        //[Required]
        //public int? DoctorId { get; }
        //[ForeignKey("DoctorId")]
        //public virtual Doctor Doctor { get; }

        public WorkTime(DateRange dateRange, TimeSpan startTime, TimeSpan endTime) 
        {
            if (Validate(startTime, endTime))
            {
                DateRange = dateRange;
                StartTime = startTime;
                EndTime = endTime;
            }
            else 
            {
                throw new Exception("Passed arguments are not valid!");
            }
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DateRange;
            yield return StartTime;
            yield return EndTime;
        }

        private bool Validate(TimeSpan startTime, TimeSpan endTime)
        {
            return  startTime < endTime;
        }
    }
}

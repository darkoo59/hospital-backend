using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalLibrary.Core.Model
{
    public class WorkTime : ValueObject
    {
        public DateRange DateRange { get; }
        public TimeRange TimeRange { get; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        //[Required]
        //public int? DoctorId { get; }
        //[ForeignKey("DoctorId")]
        //public virtual Doctor Doctor { get; }

        public WorkTime(DateRange dateRange, TimeRange timeRange) 
        {
            DateRange = dateRange;
            TimeRange = timeRange;
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DateRange;
            yield return TimeRange;
        }
        public List<DateRange> SeparateDateRange()
        {
            List<DateRange> dates = new List<DateRange>();
            for (DateTime dateTime = this.DateRange.Start; dateTime <= this.DateRange.End; dateTime = dateTime.AddDays(1))
            {
                for (int i = this.TimeRange.Start.Hours; i < this.TimeRange.End.Hours; i++)
                {
                    DateTime start = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
                    DateTime end = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
                    dates.Add(new DateRange(start.AddHours(i), end.AddHours(i).AddMinutes(30)));
                    dates.Add(new DateRange(start.AddHours(i).AddMinutes(30), end.AddHours(i+1)));
                }
            }
            return dates;
        }
    }
}

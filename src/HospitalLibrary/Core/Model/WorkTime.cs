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
        }
        public List<DateRange> SeparateDateRange()
        {
            List<DateRange> dates = new List<DateRange>();
            for (DateTime dateTime = this.DateRange.Start; dateTime <= this.DateRange.End; dateTime = dateTime.AddDays(1))
            {
                for (int i = this.StartTime.Hour; i < this.EndTime.Hour; i++)
                {
                    DateTime start = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
                    DateTime end = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
                    dates.Add(new DateRange(start.AddHours(i), end.AddHours(i).AddMinutes(30)));
                    dates.Add(new DateRange(start.AddHours(i).AddMinutes(30), end.AddHours(i + 1)));
                }
            }
            return dates;
        }
        private bool Validate(DateTime startTime, DateTime endTime)
        {
            return startTime <= endTime;
        }
    }
}

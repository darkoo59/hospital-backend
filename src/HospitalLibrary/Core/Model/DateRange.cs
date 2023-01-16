using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class DateRange : ValueObject
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public DateRange(DateTime start, DateTime end)
        {
            if (Validate(start, end))
            {
                Start = start;
                End = end;
            }
            else
            {
                throw new Exception("Passed arguments are not valid!");
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Start;
            yield return End;
        }

        private bool Validate(DateTime start, DateTime end)
        {
            return start < end;  
        }
    }
}

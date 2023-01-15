using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class TimeRange : ValueObject
    {
        public TimeSpan Start { get; }
        public TimeSpan End { get; }
        public TimeRange(TimeSpan start, TimeSpan end)
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
        private bool Validate(TimeSpan start, TimeSpan end)
        {
            return start <= end;
        }
    }
}

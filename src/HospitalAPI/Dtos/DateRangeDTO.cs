using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class DateRangeDTO
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public DateRangeDTO()
        {
        }

        public DateRangeDTO(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
    }
}

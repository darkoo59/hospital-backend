using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class ConsiliumShowDTO
    {

        public int ConsiliumId { get; set; }
        public String Topic { get; set; }
        public DateTime DateRangeStart { get; set; }
        public DateTime DateRangeEnd { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public string RoomNumber { get; set; }


        public List<int> DoctorIds { get; set; }
        public List<int> SpecializationIds { get; set; }
    }
}

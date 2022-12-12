using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.Core.Model
{
    public class Consilium
    {
        public int ConsiliumId { get; set; }
        public String Topic { get; set; }
        public DateRange DateRange { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public int RoomId { get; set; }

        public List<int> DoctorIds { get; set; }
        public List<int> SpecializationIds { get; set; }
    }
}

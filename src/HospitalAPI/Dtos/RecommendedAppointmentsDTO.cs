using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class RecommendedAppointmentsDTO
    {
        public int doctor { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public String Priority { get; set; }
    }
}

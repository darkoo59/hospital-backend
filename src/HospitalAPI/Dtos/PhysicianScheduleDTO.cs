using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class PhysicianScheduleDTO
    {
        public int PhysicianScheduleId { get; set; }
        public int DoctorId { get; set; }
        public DoctorDTO Doctor { get; set; }
        public List<WorkTimeDTO> WorkTimes { get; set; }
        public List<AppointmentDTO> Appointments { get; set; }
        public List<VacationDTO> Vacations { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class PhysicianSchedule
    {
        public int PhysicianScheduleId { get; }
        public int DoctorId { get; }
        public List<WorkTime> WorkTimes { get; }
        public List<Appointment> Appointments { get; }
        public List<Vacation> Vacations { get; }

        public PhysicianSchedule(int physicianScheduleId, int doctorId, List<WorkTime> workTimes, List<Appointment> appointments, List<Vacation> vacations)
        {
            DoctorId = doctorId;
            WorkTimes = workTimes;
            Appointments = appointments;
            Vacations = vacations;
        }
    }
}

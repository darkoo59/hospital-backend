using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public interface IPhysicianScheduleRepository
    {
        public PhysicianSchedule FindByDoctor(int doctorId);
        public List<Appointment> FindAppointmentsByDoctor(int doctorId);
    }
}

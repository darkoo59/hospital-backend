using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class PhysicianScheduleService : IPhysicianScheduleService
    {
        public List<Appointment> GetAvailableAppointments(int doctorId, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}

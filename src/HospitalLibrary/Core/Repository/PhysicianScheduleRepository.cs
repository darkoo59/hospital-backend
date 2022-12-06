using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public class PhysicianScheduleRepository : IPhysicianScheduleRepository
    {
        private readonly HospitalDbContext _context;
        public PhysicianScheduleRepository(HospitalDbContext context) 
        {
            _context = context;
        }

        public List<Appointment> FindAppointmentsByDoctor(int doctorId)
        {
            return this._context.PhysicianSchedules.Where(p => p.DoctorId == doctorId).First().Appointments;
        }

        public PhysicianSchedule FindByDoctor(int doctorId) 
        {
            return this._context.PhysicianSchedules.Where(p => p.DoctorId == doctorId).First();
        }
    }
}

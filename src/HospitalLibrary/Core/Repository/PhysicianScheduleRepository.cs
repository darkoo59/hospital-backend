using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
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
            return this._context.PhysicianSchedules.Where(p => p.DoctorId == doctorId).FirstOrDefault();
        }
        public void Schedule(Appointment appointment) 
        {

        }
        public void Create(PhysicianSchedule physicianSchedule)
        {
            _context.PhysicianSchedules.Add(physicianSchedule);
            _context.SaveChanges();
        }

        public void Delete(PhysicianSchedule physicianSchedule)
        {
            _context.PhysicianSchedules.Remove(physicianSchedule);
            _context.SaveChanges();
        }

        public PhysicianSchedule Get(int doctorId)
        {
            foreach (var physicianSchedule in GetAll().ToList())
            {
                if (physicianSchedule.DoctorId == doctorId)
                {
                    return physicianSchedule;
                }
            }

            return null;
        }

        public IEnumerable<PhysicianSchedule> GetAll()
        {
            return _context.PhysicianSchedules.Include(r => r.Appointments).ThenInclude(y => y.Patient).Include(r => r.Vacations).ToList();
        }

        public PhysicianSchedule GetById(int id)
        {
            return _context.PhysicianSchedules.Find(id);
        }

        public void Update(PhysicianSchedule physicianSchedule)
        {
            _context.Attach(physicianSchedule);
            _context.Entry(physicianSchedule).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public PhysicianSchedule GetByDoctorId(int id)
        {
            List<PhysicianSchedule> physicianSchedules = GetAll().ToList();
            
            foreach(PhysicianSchedule physicianSchedule in physicianSchedules)
            {
                if(physicianSchedule.DoctorId == id)
                {
                    return physicianSchedule;
                }
            }
            return null;
        }
    }
}

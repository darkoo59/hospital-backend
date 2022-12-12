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
        private List<Appointment> appointments;
        PhysicianSchedule ps;
        public PhysicianScheduleRepository(HospitalDbContext context) 
        {
            _context = context;
            appointments = new List<Appointment>();
            for (int i = 0; i < 2; i++)
            {
                Appointment app = new Appointment();
                app.DoctorId = 2;
                app.PatientId = 1;
                app.ScheduledDate = new DateRange(new DateTime(2022, 12, 13+i, 10, 0, 0), new DateTime(2022, 12, 13+i, 10, 30, 0));
                Appointment app1 = new Appointment();
                app1.DoctorId = 2;
                app1.PatientId = 1;
                app1.ScheduledDate = new DateRange(new DateTime(2022, 12, 13+i, 10, 30, 0), new DateTime(2022, 12, 13+i, 11, 0, 0));
                Appointment app2 = new Appointment();
                app2.DoctorId = 2;
                app2.PatientId = 1;
                app2.ScheduledDate = new DateRange(new DateTime(2022, 12, 13+i, 11, 0, 0), new DateTime(2022, 12, 13+i, 11, 30, 0));
                Appointment app3 = new Appointment();
                app3.DoctorId = 2;
                app3.PatientId = 1;
                app3.ScheduledDate = new DateRange(new DateTime(2022, 12, 13+i, 11, 30, 0), new DateTime(2022, 12, 13+i, 12, 0, 0));
                appointments.Add(app);
                appointments.Add(app1);
                appointments.Add(app2);
                appointments.Add(app3);
            }
            WorkTime wt = new WorkTime(new DateRange(new DateTime(2022, 12, 13), new DateTime(2022, 12, 15)), new TimeRange(new TimeSpan(10, 0, 0), new TimeSpan(12, 0, 0)));
            List<WorkTime> wts = new List<WorkTime>();
            wts.Add(wt);
            ps = new PhysicianSchedule(1, 2, wts, appointments);
        }
        public List<Appointment> FindAppointmentsByDoctor(int doctorId)
        {
            //return this._context.PhysicianSchedules.Where(p => p.DoctorId == doctorId).First().Appointments;
            return ps.Appointments;
        }

        public PhysicianSchedule FindByDoctor(int doctorId) 
        {
            //return this._context.PhysicianSchedules.Where(p => p.DoctorId == doctorId).FirstOrDefault();
            return ps;
        }
        public void Schedule(Appointment appointment) 
        {
            ps.Appointments.Add(appointment);
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
            return _context.PhysicianSchedules.Include(r => r.WorkTimes).Include(r => r.Appointments).Include(r => r.Vacations).ToList();
        }

        public PhysicianSchedule GetById(int id)
        {
            return _context.PhysicianSchedules.Find(id);
        }

        public void Update(PhysicianSchedule physicianSchedule)
        {
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
    }
}

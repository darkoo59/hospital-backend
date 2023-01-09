using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HospitalDbContext _context;
        public AppointmentRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public void Add(ScheduledAppointment scheduledAppointment) 
        {
            this._context.Add(scheduledAppointment);
        }
        public void Update(ScheduledAppointment scheduledAppointment)
        {
            _context.Entry(scheduledAppointment).State = EntityState.Modified;

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

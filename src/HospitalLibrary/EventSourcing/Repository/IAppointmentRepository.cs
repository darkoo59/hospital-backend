using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public interface IAppointmentRepository
    {
        public void Add(ScheduledAppointment scheduledAppointment);
        public void Update(ScheduledAppointment scheduledAppointment);
    }
}

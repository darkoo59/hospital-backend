using HospitalLibrary.Core.Model;
using HospitalLibrary.EventSourcing.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public interface IScheduledAppointmentRepository
    {
        ScheduledAppointment FindBy(int id);

        void Add(ScheduledAppointment scheduledAppointment);

        void Save(ScheduledAppointment scheduledAppointment);
        IEnumerable<Object> GetStream(string streamName, int fromVersion, int toVersion);
    }
}

using HospitalLibrary.Core.Model;
using HospitalLibrary.EventSourcing.Infrastructure;
using HospitalLibrary.EventSourcing.Model;
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
    public class ScheduledAppointmentRepository : IScheduledAppointmentRepository
    {
        private readonly EventStore _eventStore;
        public ScheduledAppointmentRepository(EventStore eventStore)
        {
            _eventStore = eventStore;
        }
        public void Add(ScheduledAppointment scheduledAppointment)
        {
            var streamName = string.Format("{0}-{1}", typeof(ScheduledAppointment).Name, scheduledAppointment.Id.ToString());

            _eventStore.CreateNewStream(streamName, scheduledAppointment.Changes);
        }

        public ScheduledAppointment FindBy(int id)
        {
            var streamName = string.Format("{0}-{1}", typeof(ScheduledAppointment).Name, id.ToString());

            // Check for snapshots

            var fromEventNumber = 0;
            var toEventNumber = int.MaxValue;

            // pull back all events from snapshot
            var stream = _eventStore.GetStream(streamName, fromEventNumber, toEventNumber);

            var ScheduledAppointment = new ScheduledAppointment();

            foreach (var @event in stream)
            {
                ScheduledAppointment.Apply((DomainEvent)@event);
            }

            return ScheduledAppointment;
        }

        public void Save(ScheduledAppointment scheduledAppointment)
        {
            var streamName = string.Format("{0}-{1}", typeof(ScheduledAppointment).Name, scheduledAppointment.Id.ToString());

            _eventStore.AppendEventsToStream(streamName, scheduledAppointment.Changes);
        }

        public IEnumerable<Object> GetStream(string streamName, int fromVersion, int toVersion)
        {
            return _eventStore.GetStream(streamName, fromVersion, toVersion);
        }
    }
}

using HospitalLibrary.EventSourcing.Infrastructure;
using HospitalLibrary.EventSourcing.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.EventSourcing.Repository
{
    public class ExaminationRepository : IExaminationRepository
    {
        private readonly EventStore _eventStore;

        public ExaminationRepository(EventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public void Add(Examination examination)
        {
            var streamName = string.Format("{0}-{1}", typeof(Examination).Name, examination.Id.ToString());

            _eventStore.CreateNewStream(streamName, examination.Changes);
        }

        public Examination FindBy(int id)
        {
            var streamName = string.Format("{0}-{1}", typeof(Examination).Name, id.ToString());

            // Check for snapshots

            var fromEventNumber = 0;
            var toEventNumber = int.MaxValue;

            // pull back all events from snapshot
            var stream = _eventStore.GetStream(streamName, fromEventNumber, toEventNumber);

            var examination = new Examination();

            foreach (var @event in stream)
            {
                examination.Apply((DomainEvent)@event);
            }

            return examination;
        }

        public void Save(Examination examination)
        {
            var streamName = string.Format("{0}-{1}", typeof(Examination).Name, examination.Id.ToString());

            _eventStore.AppendEventsToStream(streamName, examination.Changes);
        }

        public IEnumerable<Object> GetStream(string streamName, int fromVersion, int toVersion)
        {
            return _eventStore.GetStream(streamName, fromVersion, toVersion);
        }
    }
}

using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.EventSourcing.Infrastructure
{
    public class EventStore
    {
        private readonly HospitalDbContext _context;

        public EventStore(HospitalDbContext context)
        {
            _context = context;
        }

        public void CreateNewStream(string streamName, IEnumerable<Object> domainEvents)
        {
            _context.Add(new EventStream(streamName));
            _context.SaveChanges();

            AppendEventsToStream(streamName, domainEvents);
        }

        public void AppendEventsToStream(string streamName, IEnumerable<Object> domainEvents)
        {
            var stream = _context.EventStreams.Find(streamName);

            foreach (var @event in domainEvents)
            {
                _context.EventWrappers.Add(stream.RegisterEvent((DomainEvent)@event));
                _context.Entry(stream).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public IEnumerable<Object> GetStream(string streamName, int fromVersion, int toVersion)
        {
            List<EventWrapper> eventWrappers = new List<EventWrapper>();
            foreach (var eventWrapper in _context.EventWrappers.Include(r => r.Event).ToList())
            {
                if (BelongsToStream(streamName, eventWrapper) && IsValidVersion(eventWrapper, fromVersion, toVersion))
                {
                    eventWrappers.Add(eventWrapper);
                }
            }

            if (eventWrappers.Count() == 0) return null;

            var events = new List<Object>();

            foreach (var @event in eventWrappers)
            {
                events.Add(@event.Event);
            }

            return events;
        }

        private static bool BelongsToStream(string streamName, EventWrapper eventWrapper)
        {
            return eventWrapper.EventStreamId.Equals(streamName);
        }

        private static bool IsValidVersion(EventWrapper eventWrapper, int fromVersion, int toVersion)
        {
            return eventWrapper.EventNumber <= toVersion && eventWrapper.EventNumber >= fromVersion;
        }
    }
}


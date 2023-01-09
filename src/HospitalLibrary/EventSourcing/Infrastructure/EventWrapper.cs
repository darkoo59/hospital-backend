namespace HospitalLibrary.EventSourcing.Infrastructure
{
    public class EventWrapper
    {
        public string Id { get; private set; }
        public DomainEvent Event { get; private set; }
        public string EventStreamId { get; private set; }
        public int EventNumber { get; private set; }

        public EventWrapper()
        {
        }

        public EventWrapper(DomainEvent @event, int eventNumber, string streamStateId)
        {
            Event = @event;
            EventNumber = eventNumber;
            EventStreamId = streamStateId;
            Id = string.Format("{0}-{1}", streamStateId, EventNumber);
        }
    }
}
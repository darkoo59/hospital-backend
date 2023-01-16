using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.RenovationEventSourcing
{
	public class EventInvoker : IEventInvoker
	{
		private readonly IEventRepository _repository;

		public EventInvoker(IEventRepository repository)
		{
			_repository = repository;
		}

		public List<Event> GetEvents()
		{
			return _repository.GetAll().ToList();
		}

		public Event AddEvent(EventType eventType)
		{
			Event newEvent = new Event(eventType);
			_repository.Create(newEvent);
			return newEvent;
		}
	}
}

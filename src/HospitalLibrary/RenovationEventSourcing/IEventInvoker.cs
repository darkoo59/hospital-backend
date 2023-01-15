using System.Collections.Generic;

namespace HospitalLibrary.RenovationEventSourcing
{
	public interface IEventInvoker
	{
		Event AddEvent(EventType eventType);
		List<Event> GetEvents();
	}
}
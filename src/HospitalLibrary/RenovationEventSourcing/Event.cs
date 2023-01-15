using System;

namespace HospitalLibrary.RenovationEventSourcing
{
	public class Event
	{
		public int Id { get; set; }
		public EventType EventType { get; set; }
		public DateTime DateTime { get; set; }

		public Event(EventType eventType)
		{
			EventType = eventType;
			DateTime = DateTime.Now;
		}
	}
}
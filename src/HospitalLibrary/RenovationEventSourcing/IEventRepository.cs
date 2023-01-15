using System.Collections.Generic;

namespace HospitalLibrary.RenovationEventSourcing
{
	public interface IEventRepository
	{
		void Create(Event @event);
		void Delete(Event @event);
		IEnumerable<Event> GetAll();
	}
}
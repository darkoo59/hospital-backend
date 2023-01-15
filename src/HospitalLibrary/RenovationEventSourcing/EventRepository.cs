using System.Collections.Generic;
using System.Linq;
using HospitalLibrary.Settings;

namespace HospitalLibrary.RenovationEventSourcing
{
	public class EventRepository : IEventRepository
	{
		private readonly HospitalDbContext _context;

		public EventRepository(HospitalDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Event> GetAll()
		{

			return _context.Events.ToList().OrderBy(e => e.Id);
		}

		public void Create(Event @event)
		{
			@event.Id = GetId();
			_context.Events.Add(@event);
			_context.SaveChanges();
		}

		public void Delete(Event @event)
		{
			_context.Events.Remove(@event);
			_context.SaveChanges();
		}

		private int GetId()
		{
			if(GetAll().Count() == 0)
				return 0;
			return GetAll().Last().Id + 1;
		}
	}
}

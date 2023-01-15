using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.RenovationEventSourcing
{
	public class EventService : IEventService
	{
		private readonly IEventInvoker _eventInvoker;

		public EventService(IEventInvoker eventInvoker)
		{
			this._eventInvoker = eventInvoker;
		}

		public Event CreateEvent(string eventType)
		{
			return _eventInvoker.AddEvent(Enum.Parse<EventType>(eventType));
		}

		public Dictionary<string, float> GetAverageNumberOfViewsForEachStep()
		{
			Dictionary<string, float> averageNumberOfPageViews = new Dictionary<string, float>()
			{
				{ "RenovationTypePageOpened", 0 },
				{ "RenovationDetailsPageOpened", 0},
				{ "RoomDetailsPageOpened", 0 },
				{ "AppointmentsPageOpened", 0 }
			};

			Dictionary<string, float> backupDictionary = new Dictionary<string, float>(averageNumberOfPageViews);

			int numberOfSuccessfulSchedules = 0;

			foreach (Event @event in _eventInvoker.GetEvents())
			{
				if (@event.EventType == EventType.RenovationScheduled)
				{
					numberOfSuccessfulSchedules++;
					backupDictionary = new Dictionary<string, float>(averageNumberOfPageViews);
					continue;
				}
				else if (@event.EventType == EventType.Canceled)
				{
					averageNumberOfPageViews = new Dictionary<string, float>(backupDictionary);
					continue;
				}
				else if (averageNumberOfPageViews.ContainsKey(@event.EventType.ToString()))
				{
					averageNumberOfPageViews[@event.EventType.ToString()]++;
				}
			}

			foreach (var page in averageNumberOfPageViews.Keys)
			{
				if(averageNumberOfPageViews[page] != 0)
					averageNumberOfPageViews[page] /= numberOfSuccessfulSchedules;
			}

			return averageNumberOfPageViews;
		}

		public Dictionary<string, float> GetAverageNumberOfViewsForEachStepCanceled()
		{
			Dictionary<string, float> averageNumberOfPageViews = new Dictionary<string, float>()
			{
				{ "RenovationTypePageOpened", 0 },
				{ "RenovationDetailsPageOpened", 0},
				{ "RoomDetailsPageOpened", 0 },
				{ "AppointmentsPageOpened", 0 }
			};

			Dictionary<string, float> backupDictionary = new Dictionary<string, float>(averageNumberOfPageViews);

			int numberOfCanceledSchedules = 0;

			foreach (Event @event in _eventInvoker.GetEvents())
			{
				if (@event.EventType == EventType.RenovationScheduled)
				{
					averageNumberOfPageViews = new Dictionary<string, float>(backupDictionary);
					continue;
				}
				else if (@event.EventType == EventType.Canceled)
				{
					numberOfCanceledSchedules++;
					backupDictionary = new Dictionary<string, float>(averageNumberOfPageViews);
					continue;
				}
				else if (averageNumberOfPageViews.ContainsKey(@event.EventType.ToString()))
				{
					averageNumberOfPageViews[@event.EventType.ToString()]++;
				}
			}

			foreach (var page in averageNumberOfPageViews.Keys)
			{
				if (averageNumberOfPageViews[page] != 0)
					averageNumberOfPageViews[page] /= numberOfCanceledSchedules;
			}

			return averageNumberOfPageViews;
		}

		public double GetAverageSchedulingTimeInSeconds()
		{
			int numberOfSuccessfulSchedules = 0;
			DateTime? startTime = null;
			DateTime endTime;
			List<double> renovationTimes = new List<double>();

			foreach (Event @event in _eventInvoker.GetEvents())
			{
				if (@event.EventType == EventType.RenovationTypePageOpened && startTime == null)
				{
					startTime = @event.DateTime;
					continue;
				}
				else if (@event.EventType == EventType.RenovationScheduled)
				{
					endTime = @event.DateTime;
					TimeSpan timeSpan = (TimeSpan)(endTime - startTime);
					renovationTimes.Add(timeSpan.TotalSeconds);
					numberOfSuccessfulSchedules++;
					continue;
				}
				else if (@event.EventType == EventType.Canceled)
				{
					startTime = null;
					continue;
				}
			}

			double averageSchedulingTimeInSeconds = renovationTimes.Sum();
			averageSchedulingTimeInSeconds /= numberOfSuccessfulSchedules;

			return averageSchedulingTimeInSeconds;
		}

		public Dictionary<string, double> GetAveragePageTimeInSeconds()
		{
			Dictionary<string, double> averagePageTime = new Dictionary<string, double>()
			{
				{ "RenovationTypePageOpened", 0 },
				{ "RenovationDetailsPageOpened", 0},
				{ "RoomDetailsPageOpened", 0 },
				{ "AppointmentsPageOpened", 0 }
			};

			Dictionary<string, double> backupDictionary = new Dictionary<string, double>(averagePageTime);

			int numberOfSuccessfulSchedules = 0;
			Event previousEvent = null;

			foreach (Event @event in _eventInvoker.GetEvents())
			{
				if (@event.EventType == EventType.RenovationScheduled)
				{
					numberOfSuccessfulSchedules++;
					TimeSpan timeSpan = @event.DateTime - previousEvent.DateTime;
					averagePageTime[previousEvent.EventType.ToString()] += timeSpan.TotalSeconds;
					previousEvent = null;
					backupDictionary = new Dictionary<string, double>(averagePageTime);
					continue;
				}
				else if (@event.EventType == EventType.Canceled)
				{
					averagePageTime = new Dictionary<string, double>(backupDictionary);
					continue;
				}
				else if(previousEvent == null)
				{
					previousEvent = @event;
					continue;
				}
				else if (averagePageTime.ContainsKey(@event.EventType.ToString()))
				{
					TimeSpan timeSpan = @event.DateTime - previousEvent.DateTime;
					averagePageTime[previousEvent.EventType.ToString()] += timeSpan.TotalSeconds;
					previousEvent = @event;
				}
			}

			foreach (var page in averagePageTime.Keys)
			{
				if (averagePageTime[page] != 0)
					averagePageTime[page] /= numberOfSuccessfulSchedules;
			}

			return averagePageTime;
		}

		public Dictionary<string, double> GetAveragePageTimeInSecondsCanceled()
		{
			Dictionary<string, double> averagePageTime = new Dictionary<string, double>()
			{
				{ "RenovationTypePageOpened", 0 },
				{ "RenovationDetailsPageOpened", 0},
				{ "RoomDetailsPageOpened", 0 },
				{ "AppointmentsPageOpened", 0 }
			};

			Dictionary<string, double> backupDictionary = new Dictionary<string, double>(averagePageTime);

			int numberOfCanceledSchedules = 0;
			Event previousEvent = null;

			foreach (Event @event in _eventInvoker.GetEvents())
			{
				if (@event.EventType == EventType.RenovationScheduled)
				{
					averagePageTime = new Dictionary<string, double>(backupDictionary);
					previousEvent = null;
					continue;
				}
				else if (@event.EventType == EventType.Canceled)
				{
					numberOfCanceledSchedules++;
					TimeSpan timeSpan = @event.DateTime - previousEvent.DateTime;
					averagePageTime[previousEvent.EventType.ToString()] += timeSpan.TotalSeconds;
					previousEvent = null;
					backupDictionary = new Dictionary<string, double>(averagePageTime);
					continue;
				}
				else if (previousEvent == null)
				{
					previousEvent = @event;
					continue;
				}
				else if (averagePageTime.ContainsKey(@event.EventType.ToString()))
				{
					TimeSpan timeSpan = @event.DateTime - previousEvent.DateTime;
					averagePageTime[previousEvent.EventType.ToString()] += timeSpan.TotalSeconds;
					previousEvent = @event;
				}
			}

			foreach (var page in averagePageTime.Keys)
			{
				if (averagePageTime[page] != 0)
					averagePageTime[page] /= numberOfCanceledSchedules;
			}

			return averagePageTime;
		}

		public int GetNumberOfSuccessfulScheduling()
		{
			return _eventInvoker.GetEvents().Where(e => e.EventType == EventType.RenovationScheduled).Count();
		}

		public int GetNumberOfUnsuccessfulScheduling()
		{
			return _eventInvoker.GetEvents().Where(e => e.EventType == EventType.Canceled).Count();
		}

		public double GetAverageNumberOfStepsForSuccessfulSchedule() 
		{
			double averageStep = 0;
			foreach(var step in GetAverageNumberOfViewsForEachStep().Values)
			{
				averageStep += step;
			}
			return averageStep;
		}

		public double GetAverageNumberOfStepsForCanceledSchedule()
		{
			double averageStep = 0;
			foreach (var step in GetAverageNumberOfViewsForEachStepCanceled().Values)
			{
				averageStep += step;
			}
			return averageStep;
		}

		public double GetAverageTimeForSuccessfulSchedule()
		{
			double averageTime = 0;
			foreach (var step in GetAveragePageTimeInSeconds().Values)
			{
				averageTime += step;
			}
			return averageTime;
		}

		public double GetAverageTimeForCanceledSchedule()
		{
			double averageTime = 0;
			foreach (var step in GetAveragePageTimeInSecondsCanceled().Values)
			{
				averageTime += step;
			}
			return averageTime;
		}
	}
}

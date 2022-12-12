using System;

namespace HospitalLibrary.Core.Model
{
	public class FreeAppointmentRequest
	{
		public int FirstRoomId { get; set; }
		public int SecondRoomId { get; set; }
		public DateTime WantedStartDate { get; set; }
		public DateTime WantedEndDate { get; set; }
		public TimeSpan Duration { get; set; }

		public FreeAppointmentRequest(int firstRoomId, int secondRoomId, DateTime wantedStartDate, DateTime wantedEndDate, int duration, string durationTimeUnit)
		{
			FirstRoomId = firstRoomId;
			SecondRoomId = secondRoomId;
			WantedStartDate = wantedStartDate;
			WantedEndDate = wantedEndDate;

			if (durationTimeUnit.ToLower() == "minutes")
				Duration = new TimeSpan(0, duration, 0);
			else if (durationTimeUnit.ToLower() == "hours")
				Duration = new TimeSpan(duration, 0, 0);
			if (durationTimeUnit.ToLower() == "days")
				Duration = new TimeSpan(duration, 0, 0, 0);

			Validate();
		}

		private void Validate()
		{
			if (WantedStartDate > WantedEndDate)
			{
				throw new ArgumentException("Start time can't be after end time");
			}

			if (WantedStartDate + Duration > WantedEndDate)
			{
				throw new ArgumentException("Duration is longer than time span between start and end date");
			}

			if (FirstRoomId == SecondRoomId)
			{
				throw new ArgumentException("First and second rooms are same");
			}
		}
	}
}

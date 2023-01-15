using System;

namespace HospitalAPI.Dtos
{
	public class FreeAppointmentRequestDTO
	{
		public int FirstRoomId { get; set; }
		public int SecondRoomId { get; set; }
		public DateTime WantedStartDate { get; set; }
		public DateTime WantedEndDate { get; set; }
		public int Duration { get; set; }
		public string DurationTimeUnit { get; set; }
	}
}

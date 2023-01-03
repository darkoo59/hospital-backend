using System;

namespace HospitalAPI.Dtos
{
	public class MoveRequestDTO
	{
		public string type { get; set; } //EquipmentMove, RenovationSplit, RenovationMerge
		public int FirstRoomId { get; set; }
		public int SecondRoomId { get; set; }
		public DateTime ChosenStartTime { get; set; }
		public int Duration { get; set; }
		public string DurationTimeUnit { get; set; }
	}
}

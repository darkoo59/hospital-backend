using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.Core.Model
{
	public class MoveRequest
	{
		[Required]
		[Key]
		public int id { get; set; }
		public string type { get; set; } //EquipmentMove, RenovationSplit, RenovationMerge
		public int fromRoomId { get; set; }
		public int toRoomId { get; set; }
		public string equipment { get; set; }
		public int quantity { get; set; }
		public DateTime chosenStartTime { get; set; }
		public TimeSpan duration { get; set; }

		public MoveRequest()
		{

		}

		public MoveRequest(string type, int fromRoomId, int toRoomId, DateTime chosenStartTime, int duration, string durationTimeUnit)
		{
			this.type = type;
			this.fromRoomId = fromRoomId;
			this.toRoomId = toRoomId;
			this.chosenStartTime = chosenStartTime;


			if (durationTimeUnit.ToLower() == "minutes")
				this.duration = new TimeSpan(0, duration, 0);
			else if (durationTimeUnit.ToLower() == "hours")
				this.duration = new TimeSpan(duration, 0, 0);
			if (durationTimeUnit.ToLower() == "days")
				this.duration = new TimeSpan(duration, 0, 0, 0);
		}
	}
}
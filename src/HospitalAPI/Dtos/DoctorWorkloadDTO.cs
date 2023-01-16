using System;

namespace HospitalAPI.Dtos
{
	public class DoctorWorkloadDTO
	{
		public int DoctorId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}

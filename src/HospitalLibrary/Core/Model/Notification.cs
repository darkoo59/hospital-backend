namespace HospitalLibrary.Core.Model
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string Message { get; set; }
    }
}

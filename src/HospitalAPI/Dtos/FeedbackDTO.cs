namespace HospitalAPI.Dtos
{
    public class FeedbackDTO
    {
        public int Id { get; set; }
        public string Textt { get; set; }
        public string User { get; set; }
        public string Date { get; set; }
        public int PatientId { get; set; }

        public FeedbackDTO()
        {
        }

        public FeedbackDTO(int id, string textt, string user, int patientId, string date)
        {
            Id = id;
            Textt = textt;
            PatientId = patientId;
            User = user;
            Date = date;
        }
    }
}

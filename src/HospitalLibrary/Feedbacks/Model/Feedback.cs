using System;

namespace HospitalLibrary.Feedbacks.Model
{
    public class Feedback
    {
        public int Id { get; set; }
        public bool Privatisation { get; set; }
        public string Textt { get; set; }
        public string User { get; set; }
        public string Date { get; set; }
        public bool IsDisplayedPublic { get; set; }
    }
}

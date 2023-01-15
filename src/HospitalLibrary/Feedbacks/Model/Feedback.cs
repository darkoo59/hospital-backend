using HospitalLibrary.Core.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalLibrary.Feedbacks.Model
{
    public class Feedback
    {
        public int Id { get; set; }
        public bool Privatisation { get; set; }
        public string Textt { get; set; }
        public int? PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        public string Date { get; set; }
        public bool IsDisplayedPublic { get; set; }
    }
}

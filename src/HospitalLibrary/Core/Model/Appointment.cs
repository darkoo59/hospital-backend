using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalLibrary.Core.Model
{
    public class Appointment : EntityObject
    {
        [Required]
        public DateRange ScheduledDate { get; set; }
        public int? DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }
        public int? PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        public bool IsFinished { get; set; }

        public Appointment()
        {
        }

        public Appointment(DateRange scheduledDate, int? doctorId, Doctor doctor, int? patientId, Patient patient, bool isFinished)
        {
            ScheduledDate = scheduledDate;
            DoctorId = doctorId;
            Doctor = doctor;
            PatientId = patientId;
            Patient = patient;
            IsFinished = isFinished;
        }

        public bool CheckIfDateRangeInAppointment(DateRange dateRange)
        {
            if (this.ScheduledDate.Start.CompareTo(dateRange.Start) <= 0 && this.ScheduledDate.End.CompareTo(dateRange.Start) > 0)
            {
                return true;
            }
            if (this.ScheduledDate.Start.CompareTo(dateRange.End) < 0 && this.ScheduledDate.End.CompareTo(dateRange.End) >= 0)
            {
                return true;
            }
            return false;
        }
    }
}

using HospitalLibrary.EventSourcing.Infrastructure;
using HospitalLibrary.EventSourcing.Model.AppointmentEvents;
using HospitalLibrary.EventSourcing.Model.Snapshots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class ScheduledAppointment : EventSourcedAggregate
    {
        public Patient Patient { get; set; }
        public DateRange ScheduledDate { get; set; }
        public Doctor Doctor { get; set; }
        public ScheduledAppointment() 
        {
            Causes(new AppointmentStarted(DateTime.Now));
        }
        public ScheduledAppointment(AppointmentSnapshot snapshot) 
        {
            Version = snapshot.Version;
        }
        public AppointmentSnapshot GetAppointmentShapshot() 
        {
            var snapshot = new AppointmentSnapshot();

            snapshot.Version = Version;

            return snapshot;
        }
        public void SelectDate(DateTime selectedDate) 
        {
            Causes(new SelectedDate(this.Id, selectedDate, DateTime.Now));
        }
        public void SelectSpecialization(Specialization specialization) 
        {
            Causes(new SelectedSpecialization(this.Id, specialization, DateTime.Now));
        }
        public void SelectDoctor(Doctor doctor)
        {
            Causes(new SelectedDoctor(this.Id, doctor, DateTime.Now));
        }
        public void SelectTime(TimeSpan time, int appointmentId)
        {
            Causes(new SelectedTime(this.Id, time, DateTime.Now, appointmentId));
        }
        private void Causes(DomainEvent @event)
        {
            Changes.Add(@event);
            Apply(@event);
        }
        public override void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
            Version = Version++;
        }
        public void When(SelectedDate selectedDate) 
        {
            this.ScheduledDate = new DateRange(selectedDate.Date, selectedDate.Date.AddMinutes(30));
        }
        public void When(SelectedSpecialization selectedSpecialization)
        {

        }
        public void When(SelectedDoctor selectedDoctor)
        {
            this.Doctor = selectedDoctor.Doctor;
        }
        public void When(SelectedTime selectedTime)
        {
            DateTime dateTime = new DateTime(this.ScheduledDate.Start.Year, this.ScheduledDate.Start.Month, this.ScheduledDate.Start.Day);
            dateTime = dateTime.AddHours(selectedTime.Time.Hours).AddMinutes(selectedTime.Time.TotalMinutes).AddSeconds(selectedTime.Time.Minutes);
            this.ScheduledDate = new DateRange(dateTime, dateTime.AddMinutes(30));
        }
    }
}

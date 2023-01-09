using HospitalLibrary.EventSourcing.Infrastructure;
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
        { }
        public void SelectDate(DateTime start, DateTime end, DateTime selectedDate) 
        {
            Causes(new SelectedDate(this.Id, selectedDate, end - start));
        }
        public void SelectSpecialization(DateTime start, DateTime end, Specialization specialization) 
        {
            Causes(new SelectedSpecialization(this.Id, specialization, end - start));
        }
        public void SelectDoctor(DateTime start, DateTime end, Doctor doctor)
        {
            Causes(new SelectedDoctor(this.Id, doctor, end - start));
        }
        public void SelectTime(DateTime start, DateTime end, TimeSpan time)
        {
            Causes(new SelectedTime(this.Id, time, end - start));
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

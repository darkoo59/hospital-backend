using HospitalLibrary.Core.Model;
using HospitalLibrary.EventSourcing.Infrastructure;
using HospitalLibrary.EventSourcing.Model.ExaminationEvents;
using HospitalLibrary.EventSourcing.Model.Snapshots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.EventSourcing.Model
{
    public class Examination : EventSourcedAggregate
    {
        private DateRange _dateRange;
        private int _appointmentId;

        public Examination()
        {
            _dateRange = new DateRange(new DateTime(2022, 6, 6), new DateTime(2022, 7, 7));
        }

        public Examination(int appointmentId)
        {
            _dateRange = new DateRange(new DateTime(2022, 6, 6), new DateTime(2022, 7, 7));
            Causes(new ExaminationStarted(appointmentId));
        }

        public Examination(ExaminationSnapshot snapshot)
        {
            Version = snapshot.Version;
        }

        public void AddSymptoms()
        {
            Causes(new SymptomsSelected());
        }

        public void AddReport()
        {
            Causes(new ReportEntered());
        }

        public void AddRecipes()
        {
            Causes(new RecipesCreated());
        }

        public void Finish()
        {
            Causes(new ExaminationFinished());
        }

        public override void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
            Version = Version++;
        }

        public ExaminationSnapshot GetExaminationSnapshot()
        {
            var snapshot = new ExaminationSnapshot();

            // Save all state

            snapshot.Version = Version;

            return snapshot;
        }

        private void Causes(DomainEvent @event)
        {
            Changes.Add(@event);
            Apply(@event);
        }

        private void When(ExaminationStarted examinationStarted)
        {
            Id = examinationStarted.AppointmentId;
            _dateRange.Start = examinationStarted.Time; 
            _appointmentId = examinationStarted.AppointmentId;
        }

        private void When(SymptomsSelected symptomsSelected)
        {
        }

        private void When(ReportEntered reportEntered)
        {
        }

        private void When(RecipesCreated recipesCreated)
        {
        }

        private void When(ExaminationFinished examinationFinished)
        {
            _dateRange.End = examinationFinished.Time;
        }

    }
}

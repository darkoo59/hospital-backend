using HospitalLibrary.EventSourcing.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class SelectedDoctor : DomainEvent
    {
        public SelectedDoctor(int aggregateId, Doctor doctor, TimeSpan timeSpentInSeconds) : base(aggregateId)
        {
            this.Doctor = doctor;
            TimeSpentInSeconds = timeSpentInSeconds;
        }
        public Doctor Doctor { get; set; }
        public TimeSpan TimeSpentInSeconds { get; private set; }
    }
}

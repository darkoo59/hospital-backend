using HospitalLibrary.EventSourcing.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class SelectedSpecialization : DomainEvent
    {
        public SelectedSpecialization(int aggregateId, Specialization specialization, TimeSpan timeSpentInSeconds) : base(aggregateId)
        {
            this.Specialization = specialization;
            TimeSpentInSeconds = timeSpentInSeconds;
        }
        public Specialization Specialization { get; private set; }
        public TimeSpan TimeSpentInSeconds { get; private set; }
    }
}

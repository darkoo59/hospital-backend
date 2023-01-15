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
        public SelectedSpecialization(int aggregateId, Specialization specialization, DateTime start) : base(aggregateId)
        {
            this.Specialization = specialization;
            this.Start = start;
        }
        public Specialization Specialization { get; private set; }
        public DateTime Start { get; set; }
    }
}

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
        public SelectedDoctor(int aggregateId, Doctor doctor, DateTime start) : base(aggregateId)
        {
            this.Doctor = doctor;
            this.Start = start;
        }
        public Doctor Doctor { get; set; }
        public DateTime Start { get; set; }
    }
}

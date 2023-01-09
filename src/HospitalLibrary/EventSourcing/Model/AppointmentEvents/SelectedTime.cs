using HospitalLibrary.EventSourcing.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class SelectedTime : DomainEvent
    {
        public SelectedTime(int aggregateId, TimeSpan time, TimeSpan timeSpentInSeconds) : base(aggregateId)
        {
            this.Time = time;
            TimeSpentInSeconds = timeSpentInSeconds;
        }
        public TimeSpan Time { get; set; }
        public TimeSpan TimeSpentInSeconds { get; private set; }
    }
}

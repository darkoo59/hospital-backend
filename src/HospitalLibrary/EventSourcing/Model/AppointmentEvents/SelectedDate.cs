using HospitalLibrary.EventSourcing.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class SelectedDate : DomainEvent
    {
        public SelectedDate(int aggregateId, DateTime date, TimeSpan timeSpentInSeconds) : base(aggregateId)
        {
            this.Date = date;
            TimeSpentInSeconds = timeSpentInSeconds;
        }
        public DateTime Date { get; private set; }
        public TimeSpan TimeSpentInSeconds { get; private set; }
    }
}

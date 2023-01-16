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
        public SelectedDate(int aggregateId, DateTime date, DateTime start) : base(aggregateId)
        {
            this.Date = date;
            this.Start = start;
        }
        public DateTime Date { get; private set; }
        public DateTime Start { get; set; }
    }
}

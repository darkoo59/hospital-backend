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
        public SelectedTime(int aggregateId, TimeSpan time, DateTime start, int appointmentId) : base(aggregateId)
        {
            this.Time = time;
            this.Start = start;
            AppointmentId = appointmentId;
        }
        public int AppointmentId { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime Start { get; set; }
    }
}

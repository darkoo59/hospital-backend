using HospitalLibrary.Core.Model;
using HospitalLibrary.EventSourcing.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.EventSourcing.Model.AppointmentEvents
{
    public class AppointmentStarted : DomainEvent
    {
        public AppointmentStarted(DateTime start)
        {
            Start = start;
        }
        public DateTime Start { get; set; }
    }
}

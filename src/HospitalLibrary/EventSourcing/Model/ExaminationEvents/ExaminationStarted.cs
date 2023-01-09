using HospitalLibrary.EventSourcing.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.EventSourcing.Model.ExaminationEvents
{
    public class ExaminationStarted : DomainEvent
    {
        public int AppointmentId { get; private set; }

        public ExaminationStarted(int appointmentId)
        {
            AppointmentId = appointmentId;
        }

        public ExaminationStarted()
        {
        }
    }
}

using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.EventSourcing.Service
{
    public class ScheduledAppointmentService : IScheduledAppointmentService
    {
        private readonly IScheduledAppointmentRepository _scheduledAppointmentRepostiory;
        public ScheduledAppointmentService(IScheduledAppointmentRepository scheduledAppointmentRepository) 
        {
            _scheduledAppointmentRepostiory = scheduledAppointmentRepository;
        }
    }
}

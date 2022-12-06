using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public interface IPhysicianScheduleService
    {
        List<Appointment> GetAvailableAppointments(int doctorId, DateTime date);
        List<Appointment> GetRecommendedAppointments(DateRange dateRange, int doctorId, string priority);
    }
}

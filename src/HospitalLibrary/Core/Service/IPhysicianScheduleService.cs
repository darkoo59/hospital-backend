using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service
{
    public interface IPhysicianScheduleService
    {
        IEnumerable<PhysicianSchedule> GetAll();
        PhysicianSchedule GetById(int id);
        void Create(PhysicianSchedule physicianSchedule);
        void Update(PhysicianSchedule physicianSchedule);
        void Delete(PhysicianSchedule physicianSchedule);
        List<Appointment> GetAvailableAppointments(int doctorId, DateTime date);
        bool Schedule(int doctorId, Appointment appointment);
        void TransferAppointment(int doctorId, Appointment appointment);
        List<Appointment> GetRecommendedAppointments(DateRange dateRange, int doctorId, string priority);
        PhysicianSchedule Get(int doctorId);
        List<Appointment> GetAppointments(int doctorId);
        void SetAppointmentToFinish(int appointmentId);
        Dictionary<int, int> GetDoctorWorkloadForDateRangeByDays(int doctorId, DateTime startDate, DateTime endDate);
        Dictionary<int, int> GetDoctorWorkloadForDateRangeByMonths(int doctorId, DateTime startDate, DateTime endDate);
	}

}

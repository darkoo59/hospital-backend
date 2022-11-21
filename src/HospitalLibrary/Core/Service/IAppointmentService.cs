using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Service
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAll();
        Appointment GetById(int id);
        void Create(Appointment appointment);
        void Update(Appointment appointment);
        void Delete(Appointment appointment);
        List<Appointment> GetDoctorAppointments(int id);
        bool ChangeAppointmentDoctor(List<Appointment> appointmentsInVacationDate);
        bool IsDoctorScheduled(Appointment appointment, int doctorId);
        List<Appointment> GetAppointmentInVacationDateRange(int? doctorId, DateTime startDate, DateTime endDate);
        bool IsDoctorScheduledInVacationDateRange(int doctorId, DateTime dateStart, DateTime dateEnd);
    }
}

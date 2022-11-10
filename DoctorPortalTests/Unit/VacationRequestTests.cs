using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace HospitalTests.Unit
{
    public class VacationRequestTests
    {
        [Fact]
        public void Check_vacation_request_unvalid_start_date()
        {
            List<VacationRequest> requests = GetVacationRequests();
            VacationRequestService service = new(CreateVacationRequestRepository(requests));
            VacationRequest vacationRequest = service.GetById(2);

            bool IsValid = service.IsVacationDateStartValid(vacationRequest);

            Assert.False(IsValid);
        }

        [Fact]
        public void Check_vacation_request_valid_start_date()
        {
            List<VacationRequest> requests = GetVacationRequests();
            VacationRequestService service = new(CreateVacationRequestRepository(requests));
            VacationRequest vacationRequest = service.GetById(3);

            bool IsValid = service.IsVacationDateStartValid(vacationRequest);

            Assert.True(IsValid);
        }

        [Fact]
        public void Check_busy_doctor_on_vacation_date()
        {
            List<Appointment> appointments = GetAppointments();
            AppointmentService service = new(CreateAppointmentRepository(appointments));
            Appointment appointment = service.GetById(1);
            VacationRequest vacationRequest = new VacationRequest();
            vacationRequest.StartDate = DateTime.Now.AddDays(10);
            vacationRequest.EndDate = DateTime.Now.AddDays(13);

            bool isBusy = service.IsDoctorFreeOnVacationDates(appointment.DoctorId, vacationRequest);

            Assert.False(isBusy);
        }

        [Fact]
        public void Check_free_doctor_on_vacation_date()
        {
            List<Appointment> appointments = GetAppointments();
            AppointmentService service = new(CreateAppointmentRepository(appointments));
            Appointment appointment = service.GetById(1);
            VacationRequest vacationRequest = new VacationRequest();
            vacationRequest.StartDate = DateTime.Now.AddDays(10);
            vacationRequest.EndDate = DateTime.Now.AddDays(15);

            bool isBusy = service.IsDoctorFreeOnVacationDates(appointment.DoctorId, vacationRequest);

            Assert.True(isBusy);
        }

        [Fact]
        public void Check_successful_transfer()
        {
            List<Appointment> appointments = GetAppointments();
            AppointmentService service = new(CreateAppointmentRepository(appointments));
            Appointment appointment = service.GetById(1);
            VacationRequest vacationRequest = new VacationRequest();
            vacationRequest.StartDate = DateTime.Now.AddDays(10);
            vacationRequest.EndDate = DateTime.Now.AddDays(15);
            bool isBusy = service.IsDoctorFreeOnVacationDates(appointment.DoctorId, vacationRequest);

            bool isSuccessful = service.TransferAppointmentBecauseVacation(appointment,isBusy);

            Assert.True(isSuccessful);
        }

        [Fact]
        public void Check_unsuccessful_transfer()
        {
            List<Appointment> appointments = GetAppointments();
            AppointmentService service = new(CreateAppointmentRepository(appointments));
            Appointment appointment = service.GetById(1);
            VacationRequest vacationRequest = new VacationRequest();
            vacationRequest.StartDate = DateTime.Now.AddDays(10);
            vacationRequest.EndDate = DateTime.Now.AddDays(15);
            bool isBusy = service.IsDoctorFreeOnVacationDates(appointment.DoctorId, vacationRequest);

            bool isSuccessful = service.TransferAppointmentBecauseVacation(appointment, isBusy);

            Assert.False(isSuccessful);
        }







        #region private

        private static IVacationRequestRepository CreateVacationRequestRepository(List<VacationRequest> requests)
        {
            var stubRepo = new Mock<IVacationRequestRepository>();
            stubRepo.Setup(m => m.GetAll()).Returns(requests);
            stubRepo.Setup(m => m.GetById(1)).Returns(requests[0]);

            return stubRepo.Object;
        }

        private static List<VacationRequest> GetVacationRequests()
        {
            return new()
            {
                new VacationRequest() { VacationRequestId = 1, StartDate = DateTime.Now.AddDays(10) , EndDate = DateTime.Now.AddDays(15) , DoctorId = 1 , IsApproved = true , Urgency = "NoUrgent" },
                new VacationRequest() { VacationRequestId = 2, StartDate = DateTime.Now.AddDays(3), EndDate = DateTime.Now.AddDays(13), DoctorId = 2, IsApproved = true, Urgency = "Urgent" },
                new VacationRequest() { VacationRequestId = 3, StartDate = DateTime.Now.AddDays(20), EndDate = DateTime.Now.AddDays(25), DoctorId = 3, IsApproved = true, Urgency = "NoUrgent" }
            };
        }

        private static IAppointmentRepository CreateAppointmentRepository(List<Appointment> appointments)
        {
            var stubRepo = new Mock<IAppointmentRepository>();
            stubRepo.Setup(m => m.GetAll()).Returns(appointments);
            stubRepo.Setup(m => m.GetById(1)).Returns(appointments[0]);

            return stubRepo.Object;
        }

        private static List<Appointment> GetAppointments()
        {
            return new()
            {
                new Appointment() { AppointmentId = 1, DoctorId = 1, PatientId = 1, Start = DateTime.Now.AddDays(12) },
                new Appointment() { AppointmentId = 2, DoctorId = 2, PatientId = 2, Start = DateTime.Now.AddDays(20) },
                new Appointment() { AppointmentId = 3, DoctorId = 3, PatientId = 3, Start = DateTime.Now.AddDays(30) }
            };
        }
        #endregion
    }
}

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
            VacationRequest vacationRequest = service.GetById(1);

            bool IsValid = service.IsVacationDateStartValid(vacationRequest);

            Assert.False(IsValid);
        }
        
        [Fact]
        public void Check_vacation_request_valid_start_date()
        {
            List<VacationRequest> requests = GetVacationRequests();
            VacationRequestService service = new(CreateVacationRequestRepository(requests));
            VacationRequest vacationRequest = service.GetById(2);

            bool IsValid = service.IsVacationDateStartValid(vacationRequest);

            Assert.True(IsValid);
        }
        
        [Fact]
        public void Check_busy_doctor_on_vacation_date()
        {
            List<Appointment> appointments = GetAppointments();
            List<VacationRequest> vacationRequests = GetVacationRequests();
            AppointmentService appointmentService = new(CreateAppointmentRepository(appointments));
            VacationRequestService vacationRequestService = new(CreateVacationRequestRepository(vacationRequests));
            Appointment appointment = appointmentService.GetById(1);
            VacationRequest vacationRequest = vacationRequestService.GetById(3);

            bool isBusy = appointmentService.IsDoctorScheduledInVacationDateRange((int)appointment.DoctorId, vacationRequest.StartDate,vacationRequest.EndDate);

            Assert.True(isBusy);
        }

        [Fact]
        public void Check_free_doctor_on_vacation_date()
        {
            List<Appointment> appointments = GetAppointments();
            List<VacationRequest> vacationRequests = GetVacationRequests();
            AppointmentService appointmentService = new(CreateAppointmentRepository(appointments));
            VacationRequestService vacationRequestService = new(CreateVacationRequestRepository(vacationRequests));
            Appointment appointment = appointmentService.GetById(2);
            VacationRequest vacationRequest = vacationRequestService.GetById(2);

            bool isBusy = appointmentService.IsDoctorScheduledInVacationDateRange((int)appointment.DoctorId, vacationRequest.StartDate, vacationRequest.EndDate);

            Assert.False(isBusy);
        }

        [Fact]
        public void Check_successful_transfer()
        {
            List<Appointment> appointments = GetAppointments();
            List<Appointment> appointmentsForTransfer = new List<Appointment>();
            AppointmentService appointmentService = new(CreateAppointmentRepository(appointments));
            Appointment appointment = appointmentService.GetById(2);
            appointmentsForTransfer.Add(appointment);
            List<VacationRequest> vacationRequests = GetVacationRequests();
            VacationRequestService vacationRequestService = new(CreateVacationRequestRepository(vacationRequests));
            VacationRequest vacationRequest = vacationRequestService.GetById(2);
            bool isBusy = appointmentService.IsDoctorScheduledInVacationDateRange((int)appointment.DoctorId, vacationRequest.StartDate, vacationRequest.EndDate);

            bool isSuccessful = appointmentService.ChangeAppointmentDoctor(appointmentsForTransfer);

            Assert.True(isSuccessful);
        }
        /*
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
        }*/

        #region private

        private static IVacationRequestRepository CreateVacationRequestRepository(List<VacationRequest> requests)
        {
            var stubRepo = new Mock<IVacationRequestRepository>();
            stubRepo.Setup(m => m.GetAll()).Returns(requests);
            stubRepo.Setup(m => m.GetById(1)).Returns(requests[0]);
            stubRepo.Setup(m => m.GetById(2)).Returns(requests[1]);
            stubRepo.Setup(m => m.GetById(3)).Returns(requests[2]);

            return stubRepo.Object;
        }

        private static List<VacationRequest> GetVacationRequests()
        {
            return new()
            {
                new VacationRequest() { VacationRequestId = 1, StartDate = DateTime.Now.AddDays(3) , EndDate = DateTime.Now.AddDays(15) , DoctorId = 1 , Status = HospitalLibrary.Core.Enums.VacationRequestStatus.NotApproved , Urgency = "NoUrgent" },
                new VacationRequest() { VacationRequestId = 2, StartDate = DateTime.Now.AddDays(5), EndDate = DateTime.Now.AddDays(13), DoctorId = 2, Status = HospitalLibrary.Core.Enums.VacationRequestStatus.Approved, Urgency = "Urgent" },
                new VacationRequest() { VacationRequestId = 3, StartDate = DateTime.Now.AddDays(10), EndDate = DateTime.Now.AddDays(13), DoctorId = 3, Status = HospitalLibrary.Core.Enums.VacationRequestStatus.OnHold, Urgency = "NoUrgent" }
            };
        }

        private static IAppointmentRepository CreateAppointmentRepository(List<Appointment> appointments)
        {
            var stubRepo = new Mock<IAppointmentRepository>();
            stubRepo.Setup(m => m.GetAll()).Returns(appointments);
            stubRepo.Setup(m => m.GetById(1)).Returns(appointments[0]);
            stubRepo.Setup(m => m.GetById(2)).Returns(appointments[1]);
            stubRepo.Setup(m => m.GetById(3)).Returns(appointments[2]);

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

        private static IWorkTimeRepository CreateWorkTimeRepository(List<WorkTime> workTimes)
        {
            var stubRepo = new Mock<IWorkTimeRepository>();
            stubRepo.Setup(m => m.GetAll()).Returns(workTimes);
            stubRepo.Setup(m => m.GetById(1)).Returns(workTimes[0]);
            stubRepo.Setup(m => m.GetById(2)).Returns(workTimes[1]);
            stubRepo.Setup(m => m.GetById(3)).Returns(workTimes[2]);

            return stubRepo.Object;
        }

        private static List<WorkTime> GetWorkTimes()
        {
            return new()
            {
                new WorkTime() { WorkTimeId = 1, StartDate = new DateTime(1, 1, 2022), EndDate = new DateTime(31, 12, 2022), StartTime = new TimeSpan(16, 00, 00), EndTime = new TimeSpan(24, 00, 00) },
                new WorkTime() { WorkTimeId = 2, StartDate = new DateTime(1, 1, 2022), EndDate = new DateTime(31, 12, 2022), StartTime = new TimeSpan(08, 00, 00), EndTime = new TimeSpan(16, 00, 00) },
            };
        }

        private static IDoctorRepository CreateDoctorRepository(List<Doctor> doctors)
        {
            var stubRepo = new Mock<IDoctorRepository>();
            stubRepo.Setup(m => m.GetAll()).Returns(doctors);
            stubRepo.Setup(m => m.GetById(1)).Returns(doctors[0]);
            stubRepo.Setup(m => m.GetById(2)).Returns(doctors[1]);
            stubRepo.Setup(m => m.GetById(3)).Returns(doctors[2]);

            return stubRepo.Object;
        }

        private static List<Doctor> GetDoctors()
        {
            return new()
            {
                new Doctor() { DoctorId = 1, Name = "Marko", Surname = "Cvijetic", SpecializationId = 1, RoomId = 1 },
                new Doctor() { DoctorId = 2, Name = "Dejan", Surname = "Dejanovic", SpecializationId = 2, RoomId = 2 },
                new Doctor() { DoctorId = 3, Name = "Mirko", Surname = "Marjanovic", SpecializationId = 1, RoomId = 3 },
            };
        }
        #endregion
    }
}

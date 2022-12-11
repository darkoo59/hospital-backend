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

        //[Fact]
        //public void Check_busy_doctor_on_vacation_date()
        //{
        //    List<Appointment> appointments = GetAppointments();
        //    List<VacationRequest> vacationRequests = GetVacationRequests();
        //    AppointmentService appointmentService = new(CreateAppointmentRepository(appointments));
        //    VacationRequestService vacationRequestService = new(CreateVacationRequestRepository(vacationRequests));
        //    Appointment appointment = appointmentService.GetById(1);
        //    VacationRequest vacationRequest = vacationRequestService.GetById(3);

        //    bool isBusy = appointmentService.IsDoctorScheduledInVacationDateRange((int)appointment.DoctorId, vacationRequest.StartDate, vacationRequest.EndDate);

        //    Assert.True(isBusy);
        //}

        //[Fact]
        //public void Check_free_doctor_on_vacation_date()
        //{
        //    List<Appointment> appointments = GetAppointments();
        //    List<VacationRequest> vacationRequests = GetVacationRequests();
        //    AppointmentService appointmentService = new(CreateAppointmentRepository(appointments));
        //    VacationRequestService vacationRequestService = new(CreateVacationRequestRepository(vacationRequests));
        //    Appointment appointment = appointmentService.GetById(2);
        //    VacationRequest vacationRequest = vacationRequestService.GetById(2);

        //    bool isBusy = appointmentService.IsDoctorScheduledInVacationDateRange((int)appointment.DoctorId, vacationRequest.StartDate, vacationRequest.EndDate);

        //    Assert.False(isBusy);
        //}

        //[Fact]
        //public void Check_successful_transfer()
        //{
        //    List<WorkTime> workTimes = GetWorkTimes();
        //    List<Doctor> doctors = GetDoctors();
        //    DoctorService doctorService = new(CreateDoctorRepository(doctors));
        //    List<Appointment> appointments = GetAppointments();
        //    List<Appointment> appointmentsForTransfer = new List<Appointment>();
        //    AppointmentService appointmentService1 = new(CreateAppointmentRepository(appointments));
        //    Appointment appointment = appointmentService1.GetById(3);
        //    appointmentsForTransfer.Add(appointment);
        //    AppointmentService appointmentService2 = new(doctorService, CreateDoctorRepository(doctors), CreateWorkTimeRepository(workTimes), CreateAppointmentRepository(appointments));

        //    bool isSuccessful = appointmentService2.ChangeAppointmentDoctor(appointmentsForTransfer);

        //    Assert.Equal(appointment.DoctorId, 2);
        //}

        //[Fact]
        //public void Check_unsuccessful_transfer()
        //{
        //    List<WorkTime> workTimes = GetWorkTimes();
        //    List<Doctor> doctors = GetDoctors();
        //    DoctorService doctorService = new(CreateDoctorRepository(doctors));
        //    List<Appointment> appointments = GetAppointments();
        //    List<Appointment> appointmentsForTransfer = new List<Appointment>();
        //    AppointmentService appointmentService1 = new(CreateAppointmentRepository(appointments));
        //    Appointment appointment = appointmentService1.GetById(4);
        //    appointmentsForTransfer.Add(appointment);
        //    AppointmentService appointmentService2 = new(doctorService, CreateDoctorRepository(doctors), CreateWorkTimeRepository(workTimes), CreateAppointmentRepository(appointments));

        //    bool isSuccessful = appointmentService2.ChangeAppointmentDoctor(appointmentsForTransfer);

        //    Assert.Equal(appointment.DoctorId, 3);
        //}
       

        #region private

        private static IVacationRequestRepository CreateVacationRequestRepository(List<VacationRequest> requests)
        {
            var stubRepo = new Mock<IVacationRequestRepository>();
            stubRepo.Setup(m => m.GetAll()).Returns(requests);
            stubRepo.Setup(m => m.GetById(1)).Returns(requests[0]);
            stubRepo.Setup(m => m.GetById(2)).Returns(requests[1]);
            stubRepo.Setup(m => m.GetById(3)).Returns(requests[2]);
            stubRepo.Setup(m => m.GetById(4)).Returns(requests[3]);

            return stubRepo.Object;
        }

        private static List<VacationRequest> GetVacationRequests()
        {
            return new()
            {
                new VacationRequest() { VacationRequestId = 1, StartDate = DateTime.Now.AddDays(3), EndDate = DateTime.Now.AddDays(15), DoctorId = 1, Status = HospitalLibrary.Core.Enums.VacationRequestStatus.NotApproved, Urgency = "NoUrgent" },
                new VacationRequest() { VacationRequestId = 2, StartDate = DateTime.Now.AddDays(5), EndDate = DateTime.Now.AddDays(13), DoctorId = 2, Status = HospitalLibrary.Core.Enums.VacationRequestStatus.Approved, Urgency = "Urgent" },
                new VacationRequest() { VacationRequestId = 3, StartDate = DateTime.Now.AddDays(10), EndDate = DateTime.Now.AddDays(13), DoctorId = 3, Status = HospitalLibrary.Core.Enums.VacationRequestStatus.OnHold, Urgency = "NoUrgent" },
                new VacationRequest() { VacationRequestId = 4, StartDate = new DateTime(2022, 11, 26), EndDate = new DateTime(2022, 11, 30), DoctorId = 5, Status = HospitalLibrary.Core.Enums.VacationRequestStatus.OnHold, Urgency = "Urgent" },
            };
        }

        //private static IAppointmentRepository CreateAppointmentRepository(List<Appointment> appointments)
        //{
        //    var stubRepo = new Mock<IAppointmentRepository>();
        //    stubRepo.Setup(m => m.GetAll()).Returns(appointments);
        //    stubRepo.Setup(m => m.GetById(1)).Returns(appointments[0]);
        //    stubRepo.Setup(m => m.GetById(2)).Returns(appointments[1]);
        //    stubRepo.Setup(m => m.GetById(3)).Returns(appointments[2]);
        //    stubRepo.Setup(m => m.GetById(4)).Returns(appointments[3]);

        //    return stubRepo.Object;
        //}

        //private static List<Appointment> GetAppointments()
        //{
        //    return new()
        //    {
        //        new Appointment() { AppointmentId = 1, DoctorId = 1, PatientId = 1, Start = DateTime.Now.AddDays(12) },
        //        new Appointment() { AppointmentId = 2, DoctorId = 2, PatientId = 2, Start = DateTime.Now.AddDays(20) },
        //        new Appointment() { AppointmentId = 3, DoctorId = 5, PatientId = 3, Start = new DateTime(2022, 11, 28, 16, 15,0) },
        //        new Appointment() { AppointmentId = 4, DoctorId = 3, PatientId = 3, Start = new DateTime(2022, 11, 28, 16, 15, 0) }
        //    };
        //}

        //private static IWorkTimeRepository CreateWorkTimeRepository(List<WorkTime> workTimes)
        //{
        //    var stubRepo = new Mock<IWorkTimeRepository>();
        //    stubRepo.Setup(m => m.GetAll()).Returns(workTimes);
        //    stubRepo.Setup(m => m.GetById(1)).Returns(workTimes[0]);
        //    stubRepo.Setup(m => m.GetById(2)).Returns(workTimes[1]);

        //    return stubRepo.Object;
        //}

        //private static List<WorkTime> GetWorkTimes()
        //{
        //    return new()
        //    {
        //        new WorkTime() { WorkTimeId = 1, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 12, 31), StartTime = new TimeSpan(16, 00, 00), EndTime = new TimeSpan(23, 00, 00) , DoctorId = 5 },
        //        new WorkTime() { WorkTimeId = 2, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 12, 31), StartTime = new TimeSpan(16, 00, 00), EndTime = new TimeSpan(23, 00, 00) , DoctorId = 2},
        //        new WorkTime() { WorkTimeId = 3, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 12, 31), StartTime = new TimeSpan(16, 00, 00), EndTime = new TimeSpan(23, 00, 00), DoctorId = 3 },
        //    };
        //}

        private static IDoctorRepository CreateDoctorRepository(List<Doctor> doctors)
        {
            var stubRepo = new Mock<IDoctorRepository>();
            stubRepo.Setup(m => m.GetAll()).Returns(doctors);
            stubRepo.Setup(m => m.GetById(1)).Returns(doctors[0]);
            stubRepo.Setup(m => m.GetById(5)).Returns(doctors[1]);
            stubRepo.Setup(m => m.GetById(3)).Returns(doctors[2]);

            return stubRepo.Object;
        }

        private static List<Doctor> GetDoctors()
        {
            return new()
            {
                new Doctor() { DoctorId = 2, Name = "Dejan", Surname = "Dejanovic", SpecializationId = 1, RoomId = 2 },
                new Doctor() { DoctorId = 5, Name = "Marko", Surname = "Cvijetic", SpecializationId = 1, RoomId = 1 },
                new Doctor() { DoctorId = 3, Name = "Mirko", Surname = "Marjanovic", SpecializationId = 3, RoomId = 3 },
            };
        }







        #endregion
    }
}
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace HospitalTests.Unit
{
    public class ConsiliumTests
    {
        [Fact]
        public void Create_Consilium_With_Doctor()
        {
            List<Consilium> consiliums = GetConsiliums();
            List<Doctor> doctors = GetDoctors();
            List<PhysicianSchedule> physicianSchedules = GetPhysicianSchedules();
            ConsiliumService service = new(CreateConsiliumRepository(consiliums),CreateDoctorRepository(doctors),CreatePhysicianRepository(physicianSchedules));
            Consilium consilium = new Consilium();
            DateRange dateRange = new DateRange(DateTime.Now.AddDays(10), DateTime.Now.AddDays(20));
            List<int> doctorIds = new List<int>();
            doctorIds.Add(1);
            consilium.ConsiliumId = 1;
            consilium.Topic = "Pregled snimka";
            consilium.DateRange = dateRange;
            consilium.Duration = 30;
            consilium.DoctorIds = doctorIds;
            consilium.SpecializationIds = new List<int>();

            service.CreateConsiliumWithDoctors(consilium,doctorIds);

            Assert.Equal(consilium.StartTime.ToString(), "22-Dec-22 10:00:00");
        }

        [Fact]
        public void Create_Consilium_With_SpecializationId()
        {
            List<Consilium> consiliums = GetConsiliums();
            List<Doctor> doctors = GetDoctors();
            List<PhysicianSchedule> physicianSchedules = GetPhysicianSchedules();
            ConsiliumService service = new(CreateConsiliumRepository(consiliums), CreateDoctorRepository(doctors), CreatePhysicianRepository(physicianSchedules));
            Consilium consilium = new Consilium();
            DateRange dateRange = new DateRange(DateTime.Now.AddDays(10), DateTime.Now.AddDays(20));
            List<int> specIds = new List<int>();
            specIds.Add(1);
            consilium.ConsiliumId = 1;
            consilium.Topic = "Pregled snimka";
            consilium.DateRange = dateRange;
            consilium.Duration = 30;
            consilium.SpecializationIds = specIds;

            service.CreateConsiliumWithSpecializations(consilium, specIds);

            Assert.Equal(consilium.StartTime.ToString(), "22-Dec-22 10:00:00");
        }

        #region private

        private static IConsiliumRepository CreateConsiliumRepository(List<Consilium> consiliums)
        {
            var stubRepo = new Mock<IConsiliumRepository>();

            return stubRepo.Object;
        }

        private static List<Consilium> GetConsiliums()
        {
            return new()
            {
                new Consilium() { ConsiliumId = 1, Duration = 30, Topic = "Pregled snimka" }
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
                new Doctor() { DoctorId = 1, Name = "Dejan", Surname = "Dejanovic", SpecializationId = 1, RoomId = 2 },
                new Doctor() { DoctorId = 2, Name = "Marko", Surname = "Cvijetic", SpecializationId = 2, RoomId = 1 },
                new Doctor() { DoctorId = 3, Name = "Mirko", Surname = "Marjanovic", SpecializationId = 3, RoomId = 3 },
            };
        }

        private static IPhysicianScheduleRepository CreatePhysicianRepository(List<PhysicianSchedule> physicianSchedules)
        {
            var stubRepo = new Mock<IPhysicianScheduleRepository>();
            stubRepo.Setup(m => m.GetAll()).Returns(physicianSchedules);
            stubRepo.Setup(m => m.Get(1)).Returns(physicianSchedules[0]);

            return stubRepo.Object;
        }

        private static List<PhysicianSchedule> GetPhysicianSchedules()
        {
            return new()
            {
                new PhysicianSchedule { DoctorId = 1, Vacations = null, Id = 1, Appointments = new List<Appointment>() }
            };
        }



        #endregion

    }
}
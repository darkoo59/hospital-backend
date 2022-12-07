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
            ConsiliumService service = new(CreateConsiliumRepository(consiliums));
            Consilium consilium = new Consilium();
            DateRange dateRange = new DateRange(DateTime.Now.AddDays(10), DateTime.Now.AddDays(20));
            List<int> doctorIds = new List<int>();
            doctorIds.Add(1);
            consilium.ConsiliumId = 1;
            consilium.Topic = "Pregled snimka";
            consilium.DateRange = dateRange;
            consilium.Duration = 30;
            consilium.DoctorIds = doctorIds;

            service.Create(consilium);

            Assert.NotEqual(consilium.StartTime.ToString(), "01-Jan-01 0:00:00");
        }

        [Fact]
        public void Create_Consilium_With_SpecializationId()
        {
            List<Consilium> consiliums = GetConsiliums();
            ConsiliumService service = new(CreateConsiliumRepository(consiliums));
            Consilium consilium = new Consilium();
            DateRange dateRange = new DateRange(DateTime.Now.AddDays(10), DateTime.Now.AddDays(20));
            List<int> specializationIds = new List<int>();
            specializationIds.Add(1);
            consilium.ConsiliumId = 1;
            consilium.Topic = "Pregled snimka";
            consilium.DateRange = dateRange;
            consilium.Duration = 30;
            consilium.SpecializationIds = specializationIds;

            service.Create(consilium);

            Assert.NotEqual(consilium.StartTime.ToString(), "01-Jan-01 0:00:00");
        }

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
    }
}

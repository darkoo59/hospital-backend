using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.Dtos;
using HospitalAPI.Mappers;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalTests.setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace HospitalTests
{
    public class BloodRequestTests : BaseIntegrationTest
    {
        public BloodRequestTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static BloodRequestController SetupController(IServiceScope scope)
        {
            return new BloodRequestController(scope.ServiceProvider.GetRequiredService<IBloodRequestService>(), scope.ServiceProvider.GetRequiredService<IGenericMapper<BloodRequest, BloodRequestDTO>>());
        }

        [Fact]
        public void Creates_blood_request()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            BloodRequestDTO bloodRequestDTO = new BloodRequestDTO(1, "A+", 4, "Heart surgery", new DateTime(2022, 12, 13), 1);

            var result = ((OkObjectResult)controller.Create(bloodRequestDTO))?.Value as BloodRequest;

            Assert.NotNull(result);

        }
    }
}

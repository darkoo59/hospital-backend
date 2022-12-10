using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.Dtos;
using HospitalAPI.Mappers;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalTests.setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xunit;

namespace HospitalTests
{
    [Collection("Sequential")]
    public class BloodRequestTests : BaseIntegrationTest
    {
        public BloodRequestTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static BloodRequestsController SetupController(IServiceScope scope)
        {
            return new BloodRequestsController(scope.ServiceProvider.GetRequiredService<IBloodRequestService>(), scope.ServiceProvider.GetRequiredService<IGenericMapper<BloodRequest, BloodRequestDTO>>());
        }


        [Fact]
        public async void Creates_blood_request()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            BloodRequestDTO bloodRequestDTO = new BloodRequestDTO(1, "A+", 4, "Heart surgery", new DateTime(2022, 12, 13), 1);

            var r = await controller.Create(bloodRequestDTO);
            var result = ((CreatedAtActionResult)r)?.Value as BloodRequest;

            Xunit.Assert.NotNull(result);
            
        }
  
    }

}

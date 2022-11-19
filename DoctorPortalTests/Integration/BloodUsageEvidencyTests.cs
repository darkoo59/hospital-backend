using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.Dtos;
using HospitalAPI.Mappers;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalTests.setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalTests
{
    public class BloodUsageEvidencyTests : BaseIntegrationTest
    {
        public BloodUsageEvidencyTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static BloodUsageEvidencyController SetupController(IServiceScope scope)
        {
            return new BloodUsageEvidencyController(scope.ServiceProvider.GetRequiredService< IBloodUsageEvidencyService > (), scope.ServiceProvider.GetRequiredService<IBloodService>(), scope.ServiceProvider.GetRequiredService<IGenericMapper<BloodUsageEvidency, BloodUsageEvidencyDTO>>());
        }

        
        [Fact]
        public void Creates_blood_usage_evidency()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            BloodUsageEvidencyDTO bloodUsageEvidencyDTO = new BloodUsageEvidencyDTO(2, "O+", 200, "Heart surgery", 1);

            var result = ((CreatedAtActionResult)controller.Create(bloodUsageEvidencyDTO))?.Value as BloodUsageEvidency;

            Assert.NotNull(result);

        }
  
        

    }
}

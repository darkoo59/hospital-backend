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
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace HospitalTests
{
    [Collection("Sequential")]
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

              BloodUsageEvidencyDTO bloodUsageEvidencyDTO = new BloodUsageEvidencyDTO(0,"O+", 200, "Heart surgery", 1);

              var result = ((CreatedAtActionResult)controller.Create(bloodUsageEvidencyDTO))?.Value as BloodUsageEvidency;
              
              Xunit.Assert.NotEqual(0,result.BloodUsageEvidencyId);

        }


        [Fact]
        public void Creates__blood_usage_evidency_more_blood_than_in_bank()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            BloodUsageEvidencyDTO bloodUsageEvidencyDTO = new BloodUsageEvidencyDTO(0, "O+", 9000000, "Heart surgery", 1);

            var result = ((CreatedAtActionResult)controller.Create(bloodUsageEvidencyDTO))?.Value as BloodUsageEvidency;
         
            Xunit.Assert.Equal(0, result.BloodUsageEvidencyId);
         

        }

    }
}

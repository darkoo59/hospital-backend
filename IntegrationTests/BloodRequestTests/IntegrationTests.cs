using Xunit.Priority;
using Xunit;
using IntegrationAPI.Controllers;
using Microsoft.Extensions.DependencyInjection;
using IntegrationLibrary.Features.BloodRequests.Service;
using IntegrationAPI;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IntegrationLibrary.Features.BloodRequests.Model;
using IntegrationLibrary.Features.BloodRequests.DTO;
using IntegrationLibrary.Core.Enums;

namespace IntegrationTests.BloodRequestTests
{

    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    [Collection("collection")]
    public class IntegrationTests
    {
        private TestDatabaseFactory<Startup> Factory { get; }
        public IntegrationTests(TestDatabaseFactory<Startup> factory)
        {
            Factory = factory;
        }

        private static BloodRequestController SetupController(IServiceScope scope)
        {
            return new BloodRequestController(scope.ServiceProvider.GetRequiredService<IBloodRequestService>());
        }

        [Fact, Priority(2)]
        public void Get_All_Blood_Requests()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            BloodRequestController controller = SetupController(scope);

            List<BloodRequestDTO> result = ((OkObjectResult)controller.GetAll()).Value as List<BloodRequestDTO>;

            Assert.Equal(1, result[0].Id);
            Assert.Equal(2, result[1].Id);
            Assert.Equal(3, result[2].Id);
        }

        [Fact, Priority(2)]
        public void Get_Blood_Request()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            BloodRequestController controller = SetupController(scope);

            List<BloodRequestDTO> result = ((OkObjectResult)controller.GetAll()).Value as List<BloodRequestDTO>;

            Assert.Equal(1, result[0].Id);
            Assert.Equal(2, result[1].Id);
            Assert.Equal(3, result[2].Id);
        }

        [Fact, Priority(5)]
        public void Create_Blood_Request()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            BloodRequestController controller = SetupController(scope);
            BloodRequest br = new() { Id = 4, BloodType = BloodType.AB_MINUS, QuantityInLiters = 5, ReasonForRequest = "treba 4", FinalDate = new System.DateTime(), DoctorId = 3 };

            controller.Create(br);

            BloodRequestDTO expected = new(br);
            BloodRequestDTO actual = ((OkObjectResult)controller.GetById(4)).Value as BloodRequestDTO;

            Assert.True(actual.Equals(expected));
        }
    }
}

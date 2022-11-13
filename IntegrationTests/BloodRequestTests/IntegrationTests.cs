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
using System.Threading.Tasks;

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

        [Fact, Priority(2)]
        public async Task<bool> Get_New_Blood_Requests()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            BloodRequestController controller = SetupController(scope);

            IActionResult res = await controller.GetNew();

            List<BloodRequestDTO> result = ((OkObjectResult)res).Value as List<BloodRequestDTO>;

            Assert.Equal(1, result[0].Id);

            return true;
        }

        [Fact, Priority(2)]
        public async Task<bool> Get_Approved_Blood_Requests()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            BloodRequestController controller = SetupController(scope);

            IActionResult res = await controller.GetApproved();

            List<BloodRequestDTO> result = ((OkObjectResult)res).Value as List<BloodRequestDTO>;

            Assert.Equal(2, result[0].Id);

            return true;
        }

        [Fact, Priority(2)]
        public async Task<bool> Get_Declined_Blood_Requests()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            BloodRequestController controller = SetupController(scope);

            IActionResult res = await controller.GetDeclined();

            List<BloodRequestDTO> result = ((OkObjectResult)res).Value as List<BloodRequestDTO>;

            Assert.Equal(3, result[0].Id);

            return true;
        }

        [Fact, Priority(2)]
        public async Task<bool> Get_Blood_Requests_For_Update()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            BloodRequestController controller = SetupController(scope);

            IActionResult res = await controller.GetBloodrequestsForUpdate();

            List<BloodRequestDTO> result = ((OkObjectResult)res).Value as List<BloodRequestDTO>;

            Assert.Equal(4, result[0].Id);

            return true;
        }

        [Fact, Priority(5)]
        public void Create_Blood_Request()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            BloodRequestController controller = SetupController(scope);
            CreateBloodRequestDTO br = new() { BloodRequestId = 5, BloodType = BloodType.AB_MINUS, QuantityInLiters = 6, ReasonForRequest = "treba 5", FinalDate = new System.DateTime(), DoctorId = 2 };

            controller.Create(br);

            BloodRequestDTO expected = new()
            {
                Id = 5,
                BloodType = "AB-",
                QuantityInLiters = 6,
                ReasonForRequest = "treba 5",
                FinalDate = new System.DateTime(),
            };

            BloodRequestDTO actual = ((OkObjectResult)controller.GetById(5)).Value as BloodRequestDTO;

            Assert.True(actual.Equals(expected));
        }
    }
}

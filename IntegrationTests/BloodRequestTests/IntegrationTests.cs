using Xunit.Priority;
using Xunit;
using IntegrationAPI.Controllers;
using Microsoft.Extensions.DependencyInjection;
using IntegrationLibrary.Features.BloodRequests.Service;
using IntegrationAPI;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IntegrationLibrary.Features.BloodRequests.DTO;
using System.Threading.Tasks;
using IntegrationLibrary.Features.BloodRequests.Enums;
using IntegrationLibrary.Features.BloodRequests.Model;
using IntegrationLibrary.Features.Blood.Enums;

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
        public void Approve_Blood_Request()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            BloodRequestController controller = SetupController(scope);

            controller.ApproveRequest(1);

            BloodRequestDTO actual = ((OkObjectResult)controller.GetById(1)).Value as BloodRequestDTO;

            Assert.True(actual.State == BloodRequestState.APPROVED);
        }

        [Fact, Priority(5)]
        public void Decline_Blood_Request()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            BloodRequestController controller = SetupController(scope);

            controller.DeclineRequest(5);

            BloodRequestDTO actual = ((OkObjectResult)controller.GetById(5)).Value as BloodRequestDTO;

            Assert.True(actual.State == BloodRequestState.DECLINED);
        }

        [Fact, Priority(6)]
        public void Request_Adjustment()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            BloodRequestController controller = SetupController(scope);

            RequestAdjustmentDTO dto = new()
            {
                Id = 6,
                Reason = "Novi razlog"
            };

            controller.RequestAdjustment(dto);

            BloodRequestDTO actual = ((OkObjectResult)controller.GetById(6)).Value as BloodRequestDTO;

            Assert.Equal(dto.Reason, actual.ReasonForAdjustment);
            Assert.Equal(BloodRequestState.UPDATE, actual.State);
        }

        [Fact, Priority(6)]
        public void Get_All_By_Doctor_Id()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            BloodRequestController controller = SetupController(scope);

            List<BloodRequest> list = ((OkObjectResult)controller.GetAllByDoctorId(2)).Value as List<BloodRequest>;

            Assert.Equal(3, list[0].Id);
            Assert.Equal(5, list[1].Id);
        }

        [Fact, Priority(7)]
        public void Get_All_For_Adjustment_By_Doctor_Id()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            BloodRequestController controller = SetupController(scope);

            List<BloodRequest> list = ((OkObjectResult)controller.GetAllForAdjustmentByDoctorId(3)).Value as List<BloodRequest>;

            Assert.Equal(4, list[0].Id);
        }

        [Fact, Priority(14)]
        public void Update_Blood_Request_For_Adjustment()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            BloodRequestController controller = SetupController(scope);

            UpdateBloodRequestDTO dto = new()
            {
                Id = 4,
                NewReason = "Novi razlog",
                NewQuantity = 65
            };

            controller.UpdateBloodRequestForAdjustment(dto);

            BloodRequestDTO actual = ((OkObjectResult)controller.GetById(4)).Value as BloodRequestDTO;
            Assert.Equal(dto.NewReason, actual.ReasonForRequest);
            Assert.Equal(dto.NewQuantity, actual.QuantityInLiters);
            Assert.Equal(BloodRequestState.NEW, actual.State);
        }

        [Fact, Priority(15)]
        public void Create_Blood_Request()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            BloodRequestController controller = SetupController(scope);
            CreateBloodRequestDTO br = new() { BloodRequestId = 20, BloodType = BloodType.AB_MINUS, QuantityInLiters = 6, ReasonForRequest = "treba 5", FinalDate = new System.DateTime(), DoctorId = 2 };

            controller.Create(br);

            BloodRequestDTO expected = new()
            {
                Id = 20,
                BloodType = "AB-",
                QuantityInLiters = 6,
                ReasonForRequest = "treba 5",
                FinalDate = new System.DateTime(),
            };

            BloodRequestDTO actual = ((OkObjectResult)controller.GetById(20)).Value as BloodRequestDTO;

            Assert.True(actual.Equals(expected));
        }
    }
}

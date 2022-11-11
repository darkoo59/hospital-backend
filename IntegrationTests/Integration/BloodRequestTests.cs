using Xunit.Priority;
using Xunit;
using IntegrationTests.Setup;
using IntegrationAPI.Controllers;
using Microsoft.Extensions.DependencyInjection;
using IntegrationLibrary.Features.BloodRequests.Service;
using IntegrationAPI;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IntegrationLibrary.Features.BloodRequests.Model;

namespace IntegrationTests.Integration
{

    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    [Collection("collection")]
    public class BloodRequestTests
    {
        private TestDatabaseFactory<Startup> Factory { get; }
        public BloodRequestTests(TestDatabaseFactory<Startup> factory) {
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

            List<BloodRequest> result = ((OkObjectResult)controller.GetAll()).Value as List<BloodRequest>;

            Assert.Equal(1, result[0].Id);
            Assert.Equal(2, result[1].Id);
            Assert.Equal(3, result[2].Id);
        }
    }
}

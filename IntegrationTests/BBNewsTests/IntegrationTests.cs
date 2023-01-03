using IntegrationAPI;
using IntegrationAPI.Authorization;
using IntegrationAPI.Controllers;
using IntegrationLibrary.Features.BloodBankNews.Model;
using IntegrationLibrary.Features.BloodBankNews.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using Xunit;
using Xunit.Priority;

namespace IntegrationTests.BBNewsTests
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    [Collection("collection")]
    public class IntegrationTests
    {
        private TestDatabaseFactory<Startup> Factory { get; }

        public IntegrationTests(TestDatabaseFactory<Startup> factory) {
            Factory = factory;
        }

        private static BankNewsController SetupController(IServiceScope scope)
        {
            return new BankNewsController(scope.ServiceProvider.GetRequiredService<IBankNewsService>());
        }

        [Fact, Priority(2)]
        public void Get_All_News()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            BankNewsController controller = SetupController(scope);

            List<BankNews> result = ((OkObjectResult)controller.GetAll()).Value as List<BankNews>;

            Assert.Equal(1, result[0].Id);
            Assert.Equal(2, result[1].Id);
            Assert.Equal(3, result[2].Id);
        }

        [Fact, Priority(2)]
        public void Get_New_News()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            BankNewsController controller = SetupController(scope);

            List<BankNews> result = ((OkObjectResult)controller.GetNewNews()).Value as List<BankNews>;

            Assert.Equal(1, result[0].Id);
        }

        [Fact, Priority(2)]
        public void Get_Approved_News()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            BankNewsController controller = SetupController(scope);

            List<BankNews> result = ((OkObjectResult)controller.GetApprovedNews()).Value as List<BankNews>;

            Assert.Equal(3, result[0].Id);
        }

        [Fact, Priority(2)]
        public void Get_Declined_News()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            BankNewsController controller = SetupController(scope);

            List<BankNews> result = ((OkObjectResult)controller.GetDeclinedNews()).Value as List<BankNews>;

            Assert.Equal(2, result[0].Id);
        }

        [Fact, Priority(5)]
        public void Approve_News()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            BankNewsController controller = SetupController(scope);

            ActionResult res = controller.ApproveNews(1);
            
            res.ShouldBeOfType<OkResult>();
        }

        [Fact, Priority(5)]
        public void Decline_News()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            BankNewsController controller = SetupController(scope);

            ActionResult res = controller.DeclineNews(3);

            res.ShouldBeOfType<OkResult>();
        }
    }
}

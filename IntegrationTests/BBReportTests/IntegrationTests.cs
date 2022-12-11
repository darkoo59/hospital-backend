using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Priority;
using Xunit;
using IntegrationAPI;
using Microsoft.Extensions.DependencyInjection;
using IntegrationLibrary.HospitalService;
using IntegrationLibrary.Features.BloodBankReports.Service;
using IntegrationAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Shouldly;
using HospitalLibrary.Core.Model;
using IntegrationLibrary.Features.BloodBankReports.Model;
using BloodUsageEvidency = IntegrationLibrary.Features.BloodBankReports.Model.BloodUsageEvidency;

namespace IntegrationTests.BBReportTests
{
    [Collection("collection")]
    public class IntegrationTests
    {
        private TestDatabaseFactory<Startup> Factory { get; }

        public IntegrationTests(TestDatabaseFactory<Startup> factory)
        {
            Factory = factory;
        }

        private static BBReportsController SetupController(IServiceScope scope)
        {
            return new BBReportsController(scope.ServiceProvider.GetRequiredService<IBBReportsService>());
        }

        [Fact]
        public void Generate_And_Send_New_Report()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            BBReportsController controller = SetupController(scope);

            ActionResult res = controller.SendReport(1, 15);

            res.ShouldBeOfType<OkResult>();
        }

        [Fact]
        public void Get_Blood_Usage_Evidency_Data()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IBBReportsService>();

            List<BloodUsageEvidency> evidencies = service.GetEvidencies(15);

            evidencies.ShouldNotBeNull();
        }




    }
}

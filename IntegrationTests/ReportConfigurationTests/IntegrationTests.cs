using IntegrationAPI;
using IntegrationAPI.Controllers;
using IntegrationLibrary.Features.BloodBankNews.Service;
using IntegrationLibrary.Features.ReportConfigurations.Model;
using IntegrationLibrary.Features.ReportConfigurations.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace IntegrationTests.ReportConfigurationTests
{
    [Collection("collection")]
    public class IntegrationTests
    {
        private TestDatabaseFactory<Startup> Factory { get; }

        public IntegrationTests(TestDatabaseFactory<Startup> factory)
        {
            Factory = factory;
        }

        private static ReportConfigurationController SetupController(IServiceScope scope)
        {
            return new ReportConfigurationController(scope.ServiceProvider.GetRequiredService<IReportConfigurationService>());
        }

        [Fact]
        public void Create_And_Read_Report_Configuration()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            ReportConfigurationController controller = SetupController(scope);

            ReportConfiguration cfg = new()
            {
                Id = 10, 
                ReportFrequency = "* * */7 * *", 
                ReportPeriod = 7,
                BloodBankId = 1
            };
            controller.CreateOrUpdateReportConfiguration(cfg);

            ReportConfiguration rcfg = ((OkObjectResult)controller.GetById(10)).Value as ReportConfiguration;

            Assert.Equal(10, rcfg.Id);
            Assert.Equal("* * */7 * *", rcfg.ReportFrequency);
            Assert.Equal(7, rcfg.ReportPeriod);
            Assert.Equal(1, rcfg.BloodBankId);
        }
    }
}

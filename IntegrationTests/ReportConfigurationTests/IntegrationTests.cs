using IntegrationAPI;
using IntegrationAPI.Controllers;
using IntegrationLibrary.Features.BloodBankNews.Service;
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
            return new BankNewsController(scope.ServiceProvider.GetRequiredService<IBankNewsService>());
        }

    }
}

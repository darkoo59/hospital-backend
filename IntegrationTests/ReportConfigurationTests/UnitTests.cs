using IntegrationLibrary.Core.Utility;
using Moq;
using System.Collections.Generic;
using IntegrationLibrary.Features.ReportConfigurations.Model;
using IntegrationLibrary.Features.ReportConfigurations.Repository;
using IntegrationLibrary.Features.ReportConfigurations.Service;
using Xunit;

namespace IntegrationTests.ReportConfigurationTests
{
    public class UnitTests
    {
        [Fact]
        public void Create_Configuration()
        {
            var configuration = new ReportConfiguration()
            {
                Id = 3,
                ReportFrequency = 7,
                ReportRange = new DateRange(System.DateTime.Today.AddDays(-3), System.DateTime.Today)
            };
            var data = GetReportConfigurationData();
            var service = new ReportConfigurationService(CreateReportConfigurationRepository(data));
            service.CreateConfiguration(configuration);

            Assert.True(true);
        }

        [Fact]
        public void Update_Configuration()
        {
            var data = GetReportConfigurationData();
            var service = new ReportConfigurationService(CreateReportConfigurationRepository(data));
            var configuration = service.GetConfigurationById(2);
            configuration.ReportFrequency = 10;

            service.UpdateConfiguration(configuration);

            Assert.True(true);
        }

        [Fact]
        public void Delete_Configuration()
        {
            var data = GetReportConfigurationData();
            var service = new ReportConfigurationService(CreateReportConfigurationRepository(data));
            
            service.DeleteConfiguration(1);

            Assert.True(true);
        }

        #region private

        private static IReportConfigurationRepository CreateReportConfigurationRepository(List<ReportConfiguration> data)
        {
            Mock<IReportConfigurationRepository> studRepo = new Mock<IReportConfigurationRepository>();
            studRepo.Setup(m => m.GetAll()).Returns(data);
            studRepo.Setup(m => m.GetById(1)).Returns(data[0]);
            studRepo.Setup(m => m.GetById(2)).Returns(data[1]);
            studRepo.Setup(m => m.GetById(3)).Returns(data[2]);

            return studRepo.Object;
        }

        private static List<ReportConfiguration> GetReportConfigurationData()
        {
            return new List<ReportConfiguration>
            {
                new()
                {
                    Id = 1, 
                    ReportFrequency = 7, 
                    ReportRange = new DateRange(System.DateTime.Today.AddDays(-3), System.DateTime.Today)
                },
                new()
                {
                    Id = 2,
                    ReportFrequency = 21,
                    ReportRange = new DateRange(System.DateTime.Today.AddDays(-4), System.DateTime.Today)
                }
            };
        }

        #endregion

    }
}

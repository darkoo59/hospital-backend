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
                ReportFrequency = "* * */5 * *",
                ReportPeriod = 4
            };
            var data = GetReportConfigurationData();
            var service = new ReportConfigurationService(CreateReportConfigurationRepository(data));
            service.CreateConfiguration(configuration);

            Assert.True(true);
        }
        
        [Fact]
        public void Read_Configuration()
        {
            var data = GetReportConfigurationData();
            var service = new ReportConfigurationService(CreateReportConfigurationRepository(data));

            var list = service.GetReportConfigurations();

            Assert.NotEmpty(list);
        }

        [Fact]
        public void Update_Configuration()
        {
            var data = GetReportConfigurationData();
            var service = new ReportConfigurationService(CreateReportConfigurationRepository(data));
            var configuration = service.GetConfigurationById(2);
            configuration.ReportPeriod = 13;

            service.UpdateConfiguration(configuration);
            var configurationAfterUpdate = service.GetConfigurationById(2);


            Assert.Equal(13, configurationAfterUpdate.ReportPeriod);
        }

        #region private

        private static IReportConfigurationRepository CreateReportConfigurationRepository(List<ReportConfiguration> data)
        {
            Mock<IReportConfigurationRepository> studRepo = new Mock<IReportConfigurationRepository>();
            studRepo.Setup(m => m.GetAll()).Returns(data);
            studRepo.Setup(m => m.GetById(1)).Returns(data[0]);
            studRepo.Setup(m => m.GetById(2)).Returns(data[1]);

            return studRepo.Object;
        }

        private static List<ReportConfiguration> GetReportConfigurationData()
        {
            return new List<ReportConfiguration>
            {
                new()
                {
                    Id = 1, 
                    ReportFrequency = "* * * * *", 
                    ReportPeriod = 1
                },
                new()
                {
                    Id = 2,
                    ReportFrequency = "* * * * *",
                    ReportPeriod = 7
                }
            };
        }

        #endregion

    }
}

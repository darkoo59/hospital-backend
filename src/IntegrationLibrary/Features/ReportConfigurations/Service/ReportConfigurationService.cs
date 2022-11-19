using IntegrationLibrary.Features.ReportConfigurations.Model;
using System.Collections.Generic;
using IntegrationLibrary.Features.ReportConfigurations.Repository;

namespace IntegrationLibrary.Features.ReportConfigurations.Service
{
    public class ReportConfigurationService : IReportConfigurationService
    {
        private readonly IReportConfigurationRepository _reportConfigurationRepository;

        public ReportConfigurationService(IReportConfigurationRepository reportConfigurationRepository)
        {
            _reportConfigurationRepository = reportConfigurationRepository;
        }

        public void CreateConfiguration(ReportConfiguration configuration)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteConfiguration(int id)
        {
            throw new System.NotImplementedException();
        }

        public ReportConfiguration GetConfigurationById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ReportConfiguration> GetReportConfigurations()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateConfiguration(ReportConfiguration configuration)
        {
            throw new System.NotImplementedException();
        }
    }
}
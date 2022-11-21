using System.Collections.Generic;
using IntegrationLibrary.Features.ReportConfigurations.Model;

namespace IntegrationLibrary.Features.ReportConfigurations.Service
{
    public interface IReportConfigurationService
    {
        IEnumerable<ReportConfiguration> GetReportConfigurations();
        ReportConfiguration GetConfigurationById(int id);
        void CreateConfiguration(ReportConfiguration configuration);
        void UpdateConfiguration(ReportConfiguration configuration);
        void DeleteConfiguration(int id);
        void CreateOrUpdateReportConfiguration(ReportConfiguration configuration);
    }
}
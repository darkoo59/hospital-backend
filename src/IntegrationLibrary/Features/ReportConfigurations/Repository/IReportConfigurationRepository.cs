using System.Collections.Generic;
using IntegrationLibrary.Features.ReportConfigurations.Model;

namespace IntegrationLibrary.Features.ReportConfigurations.Repository
{
    public interface IReportConfigurationRepository
    {
        IEnumerable<ReportConfiguration> GetAll();
        ReportConfiguration GetById(int id);
        void Create(ReportConfiguration reportConfiguration);
        void Update(ReportConfiguration reportConfiguration);
        void Delete(int id);
    }
}
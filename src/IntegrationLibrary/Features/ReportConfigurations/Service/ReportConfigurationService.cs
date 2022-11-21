using System;
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
            _reportConfigurationRepository.Create(configuration);
        }

        public void DeleteConfiguration(int id)
        {
            _reportConfigurationRepository.Delete(id);
        }

        public ReportConfiguration GetConfigurationById(int id)
        {
            return _reportConfigurationRepository.GetById(id);
        }

        public IEnumerable<ReportConfiguration> GetReportConfigurations()
        {
            return _reportConfigurationRepository.GetAll();
        }

        public void UpdateConfiguration(ReportConfiguration configuration)
        {
            foreach (var cfg in GetReportConfigurations())
            {
                if (configuration.BloodBankId == cfg.BloodBankId)
                {
                    _reportConfigurationRepository.Update(configuration);
                }
            }
        }
        public void CreateOrUpdateReportConfiguration(ReportConfiguration configuration)
        {
            


            foreach (var cfg in GetReportConfigurations())
            {
                if (configuration.BloodBankId == cfg.BloodBankId)
                {
                    cfg.ReportPeriod = configuration.ReportPeriod;
                    cfg.ReportFrequency = configuration.ReportFrequency;

                    _reportConfigurationRepository.Update(cfg);
                    return;
                    //UpdateConfiguration(configuration);
                }
            }

            CreateConfiguration(configuration);
        }
    }
}
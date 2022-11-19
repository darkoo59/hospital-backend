using System.Collections.Generic;
using System.Linq;
using IntegrationLibrary.Features.ReportConfigurations.Model;
using IntegrationLibrary.Settings;

namespace IntegrationLibrary.Features.ReportConfigurations.Repository
{
    public class ReportConfigurationRepository : IReportConfigurationRepository
    {
        private readonly IntegrationDbContext _context;

        public ReportConfigurationRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ReportConfiguration> GetAll()
        {
            return _context.ReportConfigurations.ToList();
        }

        public ReportConfiguration GetById(int id)
        {
            return _context.ReportConfigurations.Find(id);
        }

        public void Create(ReportConfiguration reportConfiguration)
        {
            _context.ReportConfigurations.Add(reportConfiguration);
            _context.SaveChanges();
        }

        public void Update(ReportConfiguration reportConfiguration)
        {
            _context.ReportConfigurations.Update(reportConfiguration);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.ReportConfigurations.Remove(GetById(id));
        }
    }
}
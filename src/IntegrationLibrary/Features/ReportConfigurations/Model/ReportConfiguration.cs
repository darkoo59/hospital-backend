using IntegrationLibrary.Core.Utility;

namespace IntegrationLibrary.Features.ReportConfigurations.Model
{
    public class ReportConfiguration
    {
        public int Id { get; set; }
        public string ReportFrequency { get; set; }
        public int ReportPeriod { get; set; }
        public int BloodBankId { get; set; }
    }
}

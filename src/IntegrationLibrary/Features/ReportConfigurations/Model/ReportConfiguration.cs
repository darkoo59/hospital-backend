using IntegrationLibrary.Core.Utility;

namespace IntegrationLibrary.Features.ReportConfigurations.Model
{
    public class ReportConfiguration
    {
        public int Id { get; set; }
        public int ReportFrequency { get; set; }
        public DateRange ReportRange { get; set; }
        public int BloodBankId { get; set; }
    }
}

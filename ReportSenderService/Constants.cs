using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSenderService
{
    internal static class Constants
    {
        internal const string BankIdKey = "bloodBankId";
        internal const string DaysIncludedKey = "reportPeriod";
        internal const string ReportFrequencyKey = "reportFrequency";

        internal const string ConfigurationsRoute = "/ReportConfiguration";
        internal const string GenerateReportRoute = "/BBReports/send-report";
    }
}

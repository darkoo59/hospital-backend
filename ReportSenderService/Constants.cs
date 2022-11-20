using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSenderService
{
    internal static class Constants
    {
        internal const string BankIdKey = "bankId";
        internal const string DaysIncludedKey = "daysIncluded";
        internal const string ReportFrequencyKey = "reportFrequency";

        internal const string ConfigurationsRoute = "/configurations";
        internal const string GenerateReportRoute = "/send-report";
    }
}

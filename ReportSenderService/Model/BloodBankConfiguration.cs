using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSenderService.Model
{
    internal class BloodBankConfiguration
    {
        [JsonProperty(Constants.BankIdKey)]
        internal int BankId { get; set; }

        [JsonProperty(Constants.ReportFrequencyKey)]
        internal string ReportFrequency { get; set; }

        [JsonProperty(Constants.DaysIncludedKey)]
        internal int DaysIncluded { get; set; }
    }
}

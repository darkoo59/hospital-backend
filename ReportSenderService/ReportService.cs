using Cron;
using Newtonsoft.Json;
using ReportSenderService.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ReportSenderService
{
    public partial class ReportService : ServiceBase
    {
        private CronDaemon _cron;
        private HttpClient _httpClient;

        private string _configurationCheckInterval;
        private string _integrationAPIUrl;

        private List<BloodBankConfiguration> _configurations;

        public ReportService()
        {
            InitializeComponent();

            _cron = new CronDaemon();
            _httpClient = new HttpClient();

            _configurationCheckInterval = ConfigurationSettings.AppSettings["ConfigurationCheckInterval"];
            _integrationAPIUrl = ConfigurationSettings.AppSettings["IntegrationAPIUrl"];

            _configurations = new List<BloodBankConfiguration>();
        }

        private void AddConfigurationCheckActionToCron()
        {   
            _cron.Add(_configurationCheckInterval, () =>
            {
                /*_httpClient.PostAsync(_integrationAPIUrl + Constants.GenerateReportRoute,
                    new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        { Constants.BankIdKey, "5" },
                        { Constants.DaysIncludedKey, "15" }
                    })
                );*/

                this.GetBloodBankConfigurations();
            });
        }

        private void GetBloodBankConfigurations()
        {
            HttpResponseMessage result = _httpClient.GetAsync(_integrationAPIUrl + Constants.ConfigurationsRoute).Result;

            _configurations = JsonConvert.DeserializeObject<List<BloodBankConfiguration>>(
                result.Content.ReadAsStringAsync().Result
            );

            _cron.Stop();
            _cron.Clear();

            this.AddConfigurationCheckActionToCron();

            _configurations.ForEach(configuration =>
            {
                _cron.Add(configuration.ReportFrequency, () =>
                {
                    this.GenerateReportForSpecificBank(configuration);
                });
            });

            _cron.Start();
        }

        private void GenerateReportForSpecificBank(BloodBankConfiguration bankConfiguration)
        {
            _httpClient.PostAsync(
                _integrationAPIUrl + Constants.GenerateReportRoute,
                new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { Constants.BankIdKey, bankConfiguration.BankId.ToString() },
                    { Constants.DaysIncludedKey, bankConfiguration.DaysIncluded.ToString() }
                })
            );
        }

        /*public void ManualStart()
        {
            _cron.Start();

            this.AddConfigurationCheckActionToCron();
        }*/

        protected override void OnStart(string[] args)
        {
            _cron.Start();
            
            this.AddConfigurationCheckActionToCron();
        }

        protected override void OnStop()
        {
            _cron.Stop();
        }
    }
}

using Cron;
using Newtonsoft.Json;
using ReportSenderService.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.ServiceProcess;

namespace ReportSenderService
{
    public partial class EquipmentMoveService : ServiceBase
    {
        private CronDaemon _cron;
        private HttpClient _httpClient;

        private string _configurationCheckInterval;
        private string _hospitalAPIUrl;

        private List<BloodBankConfiguration> _configurations;
        //private List<MoveRequest> _moveRequests;

        public EquipmentMoveService()
        {
            InitializeComponent();

            _cron = new CronDaemon();
            _httpClient = new HttpClient();

            _configurationCheckInterval = ConfigurationSettings.AppSettings["ConfigurationCheckInterval"];
            _hospitalAPIUrl = ConfigurationSettings.AppSettings["HospitalAPIUrl"];

            _configurations = new List<BloodBankConfiguration>();
        }

        private void AddMoveEquipmentCheckToCron()
        {   
            _cron.Add(_configurationCheckInterval, () =>
            {
                this.CheckMoveRequests();
            });
        }

        private void CheckMoveRequests()
        {
            HttpResponseMessage result = _httpClient.GetAsync(_hospitalAPIUrl + "moveRequests/check").Result;
            _cron.Stop();
            _cron.Clear();

            this.AddMoveEquipmentCheckToCron();

            _cron.Start();
        }

        protected override void OnStart(string[] args)
        {
            _cron.Start();
            
            this.AddMoveEquipmentCheckToCron();
        }

        protected override void OnStop()
        {
            _cron.Stop();
        }
    }
}

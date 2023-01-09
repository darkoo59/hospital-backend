using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class EquipmentTenderService : IEquipmentTenderService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public EquipmentTenderService()
        {
        }

       

        public async Task<List<EquipmentTender>> GettAll()
        {
            using var httpClient = AppSettings.AddApiKey(new HttpClient());

            string url = AppSettings.IntegrationApiUrl + "/api/EquipmentTender";


            HttpResponseMessage response = await httpClient.GetAsync(url);

            var r  = await response.Content.ReadAsStringAsync();

            List<EquipmentTender> result = JsonConvert.DeserializeObject<List<EquipmentTender>>(r);

            return result;
        }
    }
}

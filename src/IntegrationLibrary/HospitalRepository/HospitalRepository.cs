using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Features.BloodBankReports.DTO;
using IntegrationLibrary.Features.BloodBankReports.Mapper;
using IntegrationLibrary.Features.BloodBankReports.Model;
using IntegrationLibrary.Features.UrgentBloodOrder.DTO;
using IntegrationLibrary.Settings;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IntegrationLibrary.HospitalRepository
{
    public class HospitalRepository : IHospitalRepository
    {
        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            using var httpClient = AppSettings.AddApiKey(new HttpClient());

            string url = AppSettings.HospitalApiUrl + "/api/Doctor";
            HttpResponseMessage response = await httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var ret = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<Doctor>>(ret);
        }

        public async Task<List<BloodUsageEvidency>> GetAllEvidency()
        {
            using var httpClient = AppSettings.AddApiKey(new HttpClient());

            string url = AppSettings.HospitalApiUrl + "/api/BloodUsageEvidency";
            HttpResponseMessage response = await httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var ret = await response.Content.ReadAsStringAsync();

            var list = JsonConvert.DeserializeObject<List<BloodUsageEvidencyDTO>>(ret);
            BloodUsageEvidencyMapper mapper = new BloodUsageEvidencyMapper();
            
            return mapper.ToModel(list);
        }

        public async void UpdateBloodQuantity(int bloodType, float quantity)
        {
            using var httpClient = AppSettings.AddApiKey(new HttpClient());

            UrgentOrderDTO dto = new UrgentOrderDTO();
            dto.BloodType = bloodType;
            dto.Quantity = quantity;

            string url = AppSettings.HospitalApiUrl + "/api/Bloods/add";
            var content = JsonConvert.SerializeObject(dto);

            var stringContent = new StringContent(content, UnicodeEncoding.UTF8, "application/json");

            httpClient.PatchAsync(url, stringContent);
        }
    }
}

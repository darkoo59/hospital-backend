using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class BloodRequestService : IBloodRequestService
    {
        private readonly IBloodRequestRepository _bloodRequestRepository;

        public BloodRequestService(IBloodRequestRepository bloodRequestRepository)
        {
            _bloodRequestRepository = bloodRequestRepository;
        }
        public async Task<bool> Create(BloodRequest bloodRequest)
        {
            using var httpClient = AppSettings.AddApiKey(new HttpClient());

            string url = AppSettings.IntegrationApiUrl + "/api/BloodRequest";
            var content = new StringContent(JsonSerializer.Serialize(bloodRequest), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();

            //_bloodRequestRepository.Create(bloodRequest);

            return true;
        }

        public void Delete(BloodRequest bloodRequest)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BloodRequest> GetAll()
        {
            return _bloodRequestRepository.GetAll();
        }

        public BloodRequest GetById(int id)
        {
            return _bloodRequestRepository.GetById(id);
        }

        public void Update(BloodRequest bloodRequest)
        {
            throw new NotImplementedException();
        }
    }
}

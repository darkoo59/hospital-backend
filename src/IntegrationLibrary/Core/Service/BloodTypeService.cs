using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service
{
    public class BloodTypeService : IBloodTypeService
    {
        public BloodTypeService(IUserService userService) {
            _userService = userService;
        }

        private readonly IUserService _userService;
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<Boolean> CheckBloodTypeAvailability(BloodTypesEnum bloodType, string apiKey, float bloodQuantity, string email)
        {
            User user = _userService.GetBy(email);
            string ret;
            if (bloodQuantity == 0)
            {
                HttpResponseMessage response = await _httpClient.GetAsync("http://" + user.Server + "/api/blood/type?bloodType=" + bloodType);
                ret = await response.Content.ReadAsStringAsync();
            }
            else
            {
                HttpResponseMessage response = await _httpClient.GetAsync("http://" + user.Server + "/api/blood/type/quantity");
                ret = await response.Content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject<bool>(ret);
        }
    }
}

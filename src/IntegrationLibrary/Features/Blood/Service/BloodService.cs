using IntegrationLibrary.Features.Blood.Enums;
using IntegrationLibrary.Features.BloodBank.Model;
using IntegrationLibrary.Features.BloodBank.Service;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.Blood.Service
{
    public class BloodService : IBloodService
    {
        private readonly IUserService _userService;
        private static readonly HttpClient _httpClient = new HttpClient();

        public BloodService(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<bool> CheckBloodTypeAvailability(BloodType bloodType, string apiKey, float bloodQuantity, string email)
        {
            User user = _userService.GetBy(email);
            string ret;
            string url;
            if (bloodQuantity == 0)
            {
                url = "http://" + user.Server + "/api/blood/type?email=" + email + "&bloodType=" + bloodType;
            }
            else
            {
                url = "http://" + user.Server + "/api/blood/type/quantity?email=" + email + "&bloodType=" + bloodType + "&quantity=" + bloodQuantity;
            }

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("ApiKey", apiKey);
            HttpResponseMessage response = await _httpClient.SendAsync(requestMessage);

            if (response.StatusCode.Equals(System.Net.HttpStatusCode.Unauthorized))
            {
                throw new Exception("API key is not valid");
            }
            else if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error while communicating with ISA server");
            }

            ret = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<bool>(ret);
        }
    }
}

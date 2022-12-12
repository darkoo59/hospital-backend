using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using IntegrationLibrary.Settings;
using Microsoft.AspNetCore.Http;

namespace IntegrationAPI.Authorization
{
    public static class AuthorizationUtil
    {
        public const bool ENABLED = true;
        public const bool DISABLED = false;
        public static bool AUTHORIZATION = ENABLED; 

        public static async Task<bool> Authorize(string token)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var url = AppSettings.HospitalApiUrl + "/api/users/authorization/manager";

            var response = await httpClient.GetAsync(url);
            return response.StatusCode == HttpStatusCode.OK;

        }
        

        public static bool IsAuthorized(HttpRequest request)
        {
            if (!AUTHORIZATION) return true;
            var headerValue = AuthenticationHeaderValue.Parse(request.Headers["Authorization"]);
            var credentials = headerValue.Parameter;
            return Authorize(credentials).Result;
        }
    }
}
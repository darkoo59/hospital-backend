using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using IntegrationLibrary.Settings;

namespace IntegrationAPI.Authorization
{
    public static class AuthorizationUtil
    {
        public static async Task<bool> Authorize(string token)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var url = AppSettings.HospitalApiUrl + "/api/users/authorization/manager";

            var response = await httpClient.GetAsync(url);
            return response.StatusCode == HttpStatusCode.OK;
        }
        

        public static bool IsAuthorized(AuthenticationHeaderValue header)
        {
            var credentials = header.Parameter;
            return Authorize(credentials).Result;
        }
    }
}
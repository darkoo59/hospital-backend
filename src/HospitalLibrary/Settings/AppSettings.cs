

using System.Net.Http;
using System.Net.Http.Headers;

namespace HospitalLibrary.Settings
{
    public class AppSettings
    {
        public static readonly string IntegrationApiUrl = "http://localhost:45488";
        public static readonly string IntegrationApiKey = "kljuc";

        public static HttpClient AddApiKey(HttpClient hc)
        {
            hc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("ApiKey", IntegrationApiKey);
            return hc;
        }
    }
}

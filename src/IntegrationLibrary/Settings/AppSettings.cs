

using System.Net.Http;
using System.Net.Http.Headers;

namespace IntegrationLibrary.Settings
{
    public class AppSettings
    {
        public static readonly string HospitalApiUrl = "http://localhost:16177";
        public static readonly string HospitalApiKey = "kljuc";

        public static HttpClient AddApiKey(HttpClient hc)
        {
            hc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("ApiKey", HospitalApiKey);
            return hc;
        }
    }
}

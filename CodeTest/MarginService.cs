using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PruebaIngreso
{
    public class MarginService
    {
        private readonly string apiUrl = "https://refactored-pancake.free.beeceptor.com/margin/";
        public MarginService() { }
        public async Task<string> GetMarginAsync(string code)
        {
         
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException("Code cannot be null or empty.", nameof(code));
            }

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                   
                    HttpResponseMessage response = await client.GetAsync($"{apiUrl}{code}");
                    if (response.StatusCode == HttpStatusCode.OK)
                    {

                        return await response.Content.ReadAsStringAsync();
                    }
                    return JsonConvert.SerializeObject(new { margin = 0.0 });
                }               
                catch (Exception ex)
                {                   
                    return $"Error: {ex.Message}";
                }
            }
        }
    }
}
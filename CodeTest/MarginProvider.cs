using System.Net.Http;
using System.Net;
using System;
using System.Threading.Tasks;

namespace PruebaIngreso
{
    public class MarginProvider : IMarginProvider
    {
        public readonly IMarginProvider _defaultMarginProvider;

        public MarginProvider(IMarginProvider defaultMarginProvider)
        {
            _defaultMarginProvider = defaultMarginProvider;
        }

        public async Task<string> GetMarginAsync(string code) {
            string apiUrl = "https://refactored-pancake.free.beeceptor.com/margin/";
            string apiResponse = string.Empty;

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
                }            
                catch (Exception ex)
                {
                   
                    return $"Error: {ex.Message}";
                }
            }
          return await  _defaultMarginProvider.GetMarginAsync(code);

        }
    }
}

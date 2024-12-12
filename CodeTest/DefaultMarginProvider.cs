using Newtonsoft.Json;
using System.Threading.Tasks;

namespace PruebaIngreso
{
    public class DefaultMarginProvider : IMarginProvider
    {
    
        public Task<string> GetMarginAsync(string code)
        {
            return Task.FromResult(JsonConvert.SerializeObject(new { margin = 0.0 }));
        }
    }
}
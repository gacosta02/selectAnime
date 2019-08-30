
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace SelectAnime.Helper
{
   public  class HttpHelper<T>
    {
        public async Task<T>GetRestServiceDataAsync(string serviceAdress)
        {
            var client = new HttpClient();
            client.BaseAddress = new System.Uri(serviceAdress);
            var response =
                await client.GetAsync(client.BaseAddress);
            response.EnsureSuccessStatusCode();
            var JsonResult =
             await  response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(JsonResult);
            return result;
        }
    }
}

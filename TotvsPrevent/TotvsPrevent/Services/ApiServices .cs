using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TotvsPrevent.Services
{
    public class ApiServices
    {
        public async Task<string> LoginAsync(string username, string password)
        {

            var keyValues = new List<KeyValuePair<string, string>>
             {
                   new KeyValuePair<string, string>("username", username),
                   new KeyValuePair<string, string>("password", password),
                   new KeyValuePair<string, string>("grant_type", "password"),
              };


            var request = new HttpRequestMessage(
              HttpMethod.Post, "http://localhost:52432/api/security/token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);
            var jwt = await response.Content.ReadAsStringAsync();

            JObject jwtDnamic = JsonConvert.DeserializeObject<dynamic>(jwt);
            var accessToken = jwtDnamic.Value<string>("access_token");

            return accessToken;
        }
    }
}

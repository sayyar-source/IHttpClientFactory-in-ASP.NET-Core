using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TypedClientApp.Models;

namespace TypedClientApp.common
{
    public class UserClient
    {
        private readonly HttpClient _client;
        public UserClient(HttpClient client)
        {
            _client = client;
        }
        public async Task<Userinformation> GetData()
        {
            string url= "https://randomuser.me/api";
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var data=await response.Content.ReadAsStringAsync();
           // var result1 = JsonConvert.DeserializeObject<IEnumerable<Userinformation>>(data);
            var result = JsonConvert.DeserializeObject<Userinformation>(data);

           

            return result;

        }

    }
}

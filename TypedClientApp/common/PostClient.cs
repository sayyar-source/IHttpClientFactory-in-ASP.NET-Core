using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TypedClientApp.Models;

namespace TypedClientApp.common
{
    public class PostClient
    {
        private readonly HttpClient _httpClient;
        public PostClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            httpClient.DefaultRequestHeaders.Add("auth", "bearer-token");
            _httpClient = httpClient;
        }
        public async Task<Posts> GetPosts()
        {
            var response =await _httpClient.GetAsync("/posts");
            response.EnsureSuccessStatusCode();
            var data =await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Posts>(data);
            return result;
        }
    }
}

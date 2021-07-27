using Newtonsoft.Json;
using ShopOnline.Dto.System.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.AppAdmin.Services
{
    public class UserApiService : IUserApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> Authenticate(LoginRequestDto loginRequestDto)
        {
            var jsonDto = JsonConvert.SerializeObject(loginRequestDto);
            var httpContent = new StringContent(jsonDto, Encoding.UTF8, "application/json");

            HttpClient client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:44315");
            var response = await client.PostAsync("/UserApi/Login", httpContent);
            string token = await response.Content.ReadAsStringAsync();
            return token;
        }
    }
}

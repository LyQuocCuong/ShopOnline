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
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> Authenticate(LoginUserDto loginUserDto)
        {
            var jsonDto = JsonConvert.SerializeObject(loginUserDto);
            var httpContent = new StringContent(jsonDto, Encoding.UTF8, "application/json");

            HttpClient client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:44315");
            var response = await client.PostAsync("/UserApi/Login", httpContent);
            string token = await response.Content.ReadAsStringAsync();
            return token;
        }

        public Task<bool> CreateUser(CreateUserDto createUserDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserVM>> ReadUserList()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:44315");
            var response = await client.GetAsync("/UserApi/ReadUserList");
            string resultJsonStr = await response.Content.ReadAsStringAsync();
            List<UserVM> userList = JsonConvert.DeserializeObject<List<UserVM>>(resultJsonStr);
            
            return userList;
        }

        public Task<bool> UpdateUser(UpdateUserDto updateUserDto)
        {
            throw new NotImplementedException();
        }
    }
}

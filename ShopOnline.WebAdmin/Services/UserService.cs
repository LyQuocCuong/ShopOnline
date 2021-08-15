using Newtonsoft.Json;
using ShopOnline.Dto.System.User;
using ShopOnline.Helpers.ShopOnlineApi;
using ShopOnline.Models.System.User.Dto;
using ShopOnline.Utilities.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
            ShopOnlineApiParams apiParams = new ShopOnlineApiParams()
            {
                HttpClientFactory = _httpClientFactory,
                UrlPath = "/UserApi/Login",
                Content = loginUserDto
            };
            string jsonResult = await ShopOnlineApiHelper.PostMethodAnonymous(apiParams);
            return jsonResult;
        }

        public Task<bool> CreateUser(CreateUserDto createUserDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserVM>> ReadUserList(ReadUserDto readUserDto)
        {
            ShopOnlineApiParams apiParams = new ShopOnlineApiParams()
            {
                HttpClientFactory = _httpClientFactory,
                UrlPath = "/UserApi/ReadUserList",
                Token = readUserDto.RawToken,
            };
            string jsonResult = await ShopOnlineApiHelper.GetMethod(apiParams);
            List<UserVM> userList = JsonConvert.DeserializeObject<List<UserVM>>(jsonResult);
            return userList;
        }

        public Task<bool> UpdateUser(UpdateUserDto updateUserDto)
        {
            throw new NotImplementedException();
        }
    }
}

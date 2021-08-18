using Newtonsoft.Json;
using ShopOnline.Models.System.User;
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

        public async Task<string> GenerateTokenByLoginInfo(LoginRequestDto loginRequestDto)
        {
            SOApiContentRequest contentApiRequest = new SOApiContentRequest()
            {
                HttpClientFactory = _httpClientFactory,
                UrlPath = "/UserApi/GenerateTokenByLoginInfo",
                Data = loginRequestDto
            };
            return await SOApiHelper.ExecutePostMethodAnonymous(contentApiRequest);
        }

        public Task<bool> CreateUser(CreateUserDto createUserDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDto>> ReadUserList(ReadUserDto readUserDto)
        {
            SOApiContentRequest apiParams = new SOApiContentRequest()
            {
                HttpClientFactory = _httpClientFactory,
                UrlPath = "/UserApi/ReadUserList",
                Token = readUserDto.RawToken,
            };
            string jsonResult = await SOApiHelper.ExecuteGetMethod(apiParams);
            List<UserDto> userList = JsonConvert.DeserializeObject<List<UserDto>>(jsonResult);
            return userList;
        }

        public Task<bool> UpdateUser(UpdateUserDto updateUserDto)
        {
            throw new NotImplementedException();
        }
    }
}

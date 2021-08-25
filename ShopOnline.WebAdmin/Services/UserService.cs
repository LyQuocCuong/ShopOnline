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

        public async Task<string> GetToken(LoginInfoDto loginInfoDto)
        {
            string urlPath = "/UserApi/GetToken";
            return await SOApiHelper.ExecutePostMethodAnonymous(_httpClientFactory, urlPath, loginInfoDto);
        }

        public async Task<bool> Create(string token, CreateUserDto createUserDto)
        {
            string urlPath = "/UserApi/Create";
            SOApiParams apiParams = new SOApiParams(_httpClientFactory, token, urlPath, createUserDto);;
            string jsonResult = await SOApiHelper.ExecutePostMethod(apiParams);
            return JsonConvert.DeserializeObject<bool>(jsonResult);
        }

        public async Task<bool> UpdateBasicInfo(string token, UserBasicInfoDto basicInfoDto)
        {
            string urlPath = "/UserApi/UpdateBasicInfo";
            SOApiParams apiParams = new SOApiParams(_httpClientFactory, token, urlPath, basicInfoDto); ;
            string jsonResult = await SOApiHelper.ExecutePutMethod(apiParams);
            return JsonConvert.DeserializeObject<bool>(jsonResult);
        }

        public Task<bool> UpdatePassword(string token, Guid userId, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDto>> GetUserList(string token, ReadUserDto readUserDto)
        {
            string urlPath = "/UserApi/GetUserList";
            SOApiParams apiParams = new SOApiParams(_httpClientFactory, token, urlPath, readUserDto);
            string jsonResult = await SOApiHelper.ExecuteGetMethod(apiParams);
            List<UserDto> userList = JsonConvert.DeserializeObject<List<UserDto>>(jsonResult);
            return userList;
        }

        public async Task<UserDto> GetByUserId(string token, Guid userId)
        {
            string urlPath = $"/UserApi/GetByUserId?userId={userId}";
            SOApiParams apiParams = new SOApiParams(_httpClientFactory, token, urlPath, null);
            string jsonResult = await SOApiHelper.ExecuteGetMethod(apiParams);
            UserDto userList = JsonConvert.DeserializeObject<UserDto>(jsonResult);
            return userList;
        }
    }
}

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
using Microsoft.AspNetCore.Http;
using ShopOnline.WebAdmin.Helpers;

namespace ShopOnline.WebAdmin.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpClientFactory httpClientFactory,
                           IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<SOApiResult<string>> GetToken(LoginInfoDto loginInfoDto)
        {
            string urlPath = "/UserApi/GetToken";
            return await SOApiHelper.ExecutePostMethodAnonymous<string>(_httpClientFactory, urlPath, loginInfoDto);
        }

        public async Task<SOApiResult<bool>> Create(CreateUserDto createUserDto)
        {
            string urlPath = "/UserApi/Create";
            string token = WebAdminHelper.GetToken(_httpContextAccessor);
            SOApiParams apiParams = new SOApiParams(_httpClientFactory, token, urlPath, createUserDto);;
            return await SOApiHelper.ExecutePostMethod<bool>(apiParams);
        }

        public async Task<SOApiResult<bool>> UpdateBasicInfo(UserBasicInfoDto basicInfoDto)
        {
            string urlPath = "/UserApi/UpdateBasicInfo";
            string token = WebAdminHelper.GetToken(_httpContextAccessor);
            SOApiParams apiParams = new SOApiParams(_httpClientFactory, token, urlPath, basicInfoDto); ;
            return await SOApiHelper.ExecutePutMethod<bool>(apiParams);
        }

        public Task<SOApiResult<bool>> UpdatePassword(Guid userId, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task<SOApiResult<List<UserDto>>> GetUserList(ReadUserDto readUserDto)
        {
            string urlPath = "/UserApi/GetUserList";
            string token = WebAdminHelper.GetToken(_httpContextAccessor);
            SOApiParams apiParams = new SOApiParams(_httpClientFactory, token, urlPath, readUserDto);
            return await SOApiHelper.ExecuteGetMethod<List<UserDto>>(apiParams);
        }

        public async Task<SOApiResult<UserDto>> GetByUserId(Guid userId)
        {
            string urlPath = $"/UserApi/GetByUserId?userId={userId}";
            string token = WebAdminHelper.GetToken(_httpContextAccessor);
            SOApiParams apiParams = new SOApiParams(_httpClientFactory, token, urlPath, null);
            return await SOApiHelper.ExecuteGetMethod<UserDto>(apiParams);
        }
    }
}

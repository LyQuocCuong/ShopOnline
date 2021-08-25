using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopOnline.Models.System.User.Dto;
using ShopOnline.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.BackendApi.Controllers
{
    [ApiController]
    [Authorize]
    public class UserApiController : Controller
    {
        private readonly IUserApiService _userApiService;

        public UserApiController(IUserApiService userApiService)
        {
            _userApiService = userApiService;
        }

        /// <summary>
        /// if Login succeed, then return a new jwt
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        public async Task<string> GenerateTokenByLoginInfo([FromBody]LoginRequestDto loginRequestDto)
        {
            string token = "";
            if (await _userApiService.IsSucceedLogin(loginRequestDto))
            {
                token = await _userApiService.GenerateToken(loginRequestDto);
            }
            return token;
        }

        //https:localhost/UserApi/Create
        [HttpPost]
        public async Task<bool> Create([FromBody]CreateUserDto createUserDto)
        {
            return await _userApiService.Create(createUserDto);
        }

        [HttpPut]
        public async Task<bool> UpdateBasicInfo([FromBody] UserBasicInfoDto basicInfoDto)
        {
            return await _userApiService.UpdateBasicInfo(basicInfoDto);
        }

        [HttpPut]
        public async Task<bool> UpdatePassword([FromQuery] Guid userId, [FromBody] string newPassword)
        {
            return await _userApiService.UpdatePassword(userId, newPassword);
        }

        [HttpGet]
        public string GetUserList()
        {
            ReadUserDto readUserDto = new ReadUserDto();
            return JsonConvert.SerializeObject(_userApiService.GetUserList(readUserDto));
        }

        //https:localhost/UserApi/Create
        [HttpGet]
        public async Task<string> GetByUserId([FromQuery]Guid userId)
        {
            ReadUserDto readUserDto = new ReadUserDto();
            return JsonConvert.SerializeObject(await _userApiService.GetByUserId(userId));
        }

    }
}

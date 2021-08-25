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
    [Route("[controller]")]
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
        [HttpPost("GetToken")]
        public async Task<string> GetToken([FromBody]LoginInfoDto loginInfoDto)
        {
            string token = "";
            if (await _userApiService.IsSucceedLogin(loginInfoDto))
            {
                token = await _userApiService.GenerateToken(loginInfoDto.UserName);
            }
            return token;
        }

        //https:localhost/UserApi/Create
        [HttpPost("Create")]
        public async Task<bool> Create([FromBody]CreateUserDto createUserDto)
        {
            return await _userApiService.Create(createUserDto);
        }

        [HttpPut("UpdateBasicInfo")]
        public async Task<bool> UpdateBasicInfo([FromBody] UserBasicInfoDto basicInfoDto)
        {
            return await _userApiService.UpdateBasicInfo(basicInfoDto);
        }

        [HttpPut("UpdatePassword")]
        public async Task<bool> UpdatePassword([FromQuery] Guid userId, [FromBody] string newPassword)
        {
            return await _userApiService.UpdatePassword(userId, newPassword);
        }

        [HttpGet("GetUserList")]
        public string GetUserList()
        {
            ReadUserDto readUserDto = new ReadUserDto();
            return JsonConvert.SerializeObject(_userApiService.GetUserList(readUserDto));
        }

        [HttpGet("GetByUserId")]
        public async Task<string> GetByUserId([FromQuery]Guid userId)
        {
            ReadUserDto readUserDto = new ReadUserDto();
            return JsonConvert.SerializeObject(await _userApiService.GetByUserId(userId));
        }

    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopOnline.Helpers.ShopOnlineApi;
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
        /// <returns>STRING</returns>
        [AllowAnonymous]
        [HttpPost("GetToken")]
        public async Task<IActionResult> GetToken([FromBody]LoginInfoDto loginInfoDto)
        {
            SOApiResult<bool> resultLogin = await _userApiService.IsSucceedLogin(loginInfoDto);
            if (resultLogin.IsSucceed)
            {
                SOApiResult<string> result = await _userApiService.GenerateToken(loginInfoDto.UserName);
                if (result.IsSucceed)
                {
                    return Ok(result.ReturnedDataJSON);
                }
                return BadRequest(result.Message);
            }
            return BadRequest(resultLogin.Message);
        }

        /// https:localhost/UserApi/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]CreateUserDto createUserDto)
        {
            SOApiResult<bool> result = await _userApiService.Create(createUserDto);
            if (result.IsSucceed)
            {
                return Ok();
            }
            return BadRequest(result.Message);
        }

        [HttpPut("UpdateBasicInfo")]
        public async Task<IActionResult> UpdateBasicInfo([FromBody] UserBasicInfoDto basicInfoDto)
        {
            SOApiResult<bool> result = await _userApiService.UpdateBasicInfo(basicInfoDto);
            if (result.IsSucceed)
            {
                return Ok();
            }
            return BadRequest(result.Message);
        }

        [HttpPut("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword([FromQuery] Guid userId, [FromBody] string newPassword)
        {
            SOApiResult<bool> result = await _userApiService.UpdatePassword(userId, newPassword);
            if (result.IsSucceed)
            {
                return Ok();
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetUserList")]
        public IActionResult GetUserList()
        {
            ReadUserDto readUserDto = new ReadUserDto();
            SOApiResult<List<UserDto>> result = _userApiService.GetUserList(readUserDto);
            if (result.IsSucceed)
            {
                return Ok(result.ReturnedDataJSON);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetByUserId")]
        public async Task<IActionResult> GetByUserId([FromQuery]Guid userId)
        {
            SOApiResult<UserDto> result = await _userApiService.GetByUserId(userId);
            if (result.IsSucceed)
            {
                return Ok(result.ReturnedDataJSON);
            }
            return BadRequest(result.Message);
        }

    }
}

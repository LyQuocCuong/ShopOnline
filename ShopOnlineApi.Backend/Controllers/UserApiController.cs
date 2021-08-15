using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopOnline.Dto.System.User;
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

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string token = await _userApiService.GetJWT(loginUserDto);
            if (!string.IsNullOrEmpty(token))
            {
                return Ok(token);
            }
            return BadRequest("Bad");
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm]CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _userApiService.CreateUser(createUserDto) == true)
            {
                return Ok("Successfully");
            }
            return BadRequest("Bad");
        }

        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromForm]UpdateUserDto updateUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _userApiService.UpdateUser(updateUserDto) == true)
            {
                return Ok("Successfully");
            }
            return BadRequest("Bad");
        }

        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromQuery] Guid userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _userApiService.DeleteUser(userId) == true)
            {
                return Ok("Successfully");
            }
            return BadRequest("Bad");
        }

        [HttpGet("ReadUserList")]
        public string ReadUserList()
        {
            ReadUserDto readUserDto = new ReadUserDto();
            return JsonConvert.SerializeObject(_userApiService.ReadUserList(readUserDto));
        }

    }
}

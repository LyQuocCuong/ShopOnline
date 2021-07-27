using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Dto.System.User;
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
        private readonly IUserPublicService _userPublicService;

        public UserApiController(IUserPublicService userPublicService)
        {
            _userPublicService = userPublicService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string token = await _userPublicService.Login(loginRequestDto);
            if (!string.IsNullOrEmpty(token))
            {
                return Ok(token);
            }
            return BadRequest("Bad");
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm]RegisterRequestDto registerRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _userPublicService.Register(registerRequestDto) == true)
            {
                return Ok("Successfully");
            }
            return BadRequest("Bad");
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using ShopOnline.Dto.System.User;
using ShopOnline.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserPublicService _userPublicService;

        public UserController(IUserPublicService userPublicService)
        {
            _userPublicService = userPublicService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] LoginRequestDto loginRequestDto)
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

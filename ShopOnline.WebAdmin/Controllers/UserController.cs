using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopOnline.AppAdmin.Services;
using ShopOnline.Models.System.User.Dto;
using ShopOnline.Utilities.Consts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopOnline.WebAdmin.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, 
                            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ReadUserList()
        {
            ReadUserDto readUserDto = new ReadUserDto()
            {
                RawToken = HttpContext.Session.GetString(SystemConst.TOKEN_NAME)
            };
            List<UserDto> userList = await _userService.ReadUserList(readUserDto);
            return View(userList);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserDto createUserDto)
        {
            return View();
        }

    }
}

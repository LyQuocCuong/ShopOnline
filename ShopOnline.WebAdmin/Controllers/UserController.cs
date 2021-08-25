using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopOnline.AppAdmin.Services;
using ShopOnline.Models.System.User.Dto;
using ShopOnline.Utilities.Consts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopOnline.WebAdmin.Controllers
{

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
        public async Task<IActionResult> GetUserList()
        {
            string token = HttpContext.Session.GetString(SystemConst.TOKEN_NAME);
            ReadUserDto readUserDto = new ReadUserDto()
            {
                RawToken = HttpContext.Session.GetString(SystemConst.TOKEN_NAME)
            };
            List<UserDto> userList = await _userService.GetUserList(token, readUserDto);
            return View("UserList", userList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto createUserDto)
        {
            if (true)
            {
                string token = HttpContext.Session.GetString(SystemConst.TOKEN_NAME);
                ViewBag.Result = await _userService.Create(token, createUserDto);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            string token = HttpContext.Session.GetString(SystemConst.TOKEN_NAME);
            UserDto userDto = await _userService.GetByUserId(token, userId);
            UserBasicInfoDto basicInfoDto = new UserBasicInfoDto()
            {
                UserId = userDto.UserId,
                FullName = userDto.FullName,
                DOB = userDto.DOB,
                Email = userDto.Email
            };
            return View("UpdateBasicInfo", basicInfoDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserBasicInfoDto basicInfoDto)
        {
            if (true)
            {
                string token = HttpContext.Session.GetString(SystemConst.TOKEN_NAME);
                ViewBag.Result = await _userService.UpdateBasicInfo(token, basicInfoDto);
            }
            return RedirectToAction("GetUserList");
        }

    }
}

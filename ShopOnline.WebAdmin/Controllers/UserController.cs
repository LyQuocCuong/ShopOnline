using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopOnline.WebAdmin.Services;
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
            ReadUserDto readUserDto = new ReadUserDto();
            List<UserDto> userList = await _userService.GetUserList(readUserDto);
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
                ViewBag.Result = await _userService.Create(createUserDto);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            UserDto userDto = await _userService.GetByUserId(userId);
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
                ViewBag.Result = await _userService.UpdateBasicInfo(basicInfoDto);
            }
            return RedirectToAction("GetUserList");
        }

    }
}

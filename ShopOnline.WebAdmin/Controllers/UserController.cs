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
using ShopOnline.Helpers.ShopOnlineApi;

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
            SOApiResult<List<UserDto>> result = await _userService.GetUserList(readUserDto);
            if (!result.IsSucceed)
            {
                //Log Here
                return View("UserList", new List<UserDto>());
            }
            return View("UserList", result.ReturnedData);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto createUserDto)
        {
            SOApiResult<bool> result = await _userService.Create(createUserDto);
            if (!result.IsSucceed)
            {
                //Log Here
            }
            ViewBag.Result = result.IsSucceed;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            UserBasicInfoDto basicInfoDto = new UserBasicInfoDto();
            SOApiResult<UserDto> result = await _userService.GetByUserId(userId);
            if (!result.IsSucceed)
            {
                //Log Here
            }
            else 
            {
                UserDto userDto = result.ReturnedData;
                basicInfoDto.UserId = userDto.UserId;
                basicInfoDto.FullName = userDto.FullName;
                basicInfoDto.DOB = userDto.DOB;
                basicInfoDto.Email = userDto.Email;
            };
            return View("UpdateBasicInfo", basicInfoDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserBasicInfoDto basicInfoDto)
        {
            SOApiResult<bool> result = await _userService.UpdateBasicInfo(basicInfoDto);
            if (!result.IsSucceed)
            {
                //Log Here
            }
            ViewBag.Result = result.IsSucceed;
            return RedirectToAction("GetUserList");
        }

    }
}

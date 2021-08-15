using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using ShopOnline.AppAdmin.Services;
using ShopOnline.Dto.System.User;
using ShopOnline.Models.System.User.Dto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.AppAdmin.Controllers
{ 
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(IConfiguration configuration, 
                            ILogger<UserController> logger, 
                            IUserService userService)
        {
            _configuration = configuration;
            _logger = logger;
            _userService = userService;
        }

        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            string token = await _userService.Authenticate(loginUserDto);
            
            ClaimsPrincipal userPrincipal = this.ValidateToken(token);
            //cookie
            var authProp = new AuthenticationProperties()
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(1),
                IsPersistent = true,
            };
            await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            userPrincipal,
                            authProp);
            HttpContext.Session.SetString("Token", token);
            return RedirectToAction("Index", "Home");
        }

        private ClaimsPrincipal ValidateToken(string token)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();
            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = _configuration["Token:Issuer"];
            validationParameters.ValidIssuer = _configuration["Token:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Secrect_Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler()
                                            .ValidateToken(token, validationParameters, out validatedToken);
            return principal;

        }

        [HttpGet]
        public async Task<IActionResult> ReadUserList()
        {
            ReadUserDto readUserDto = new ReadUserDto()
            {
                RawToken = HttpContext.Session.GetString("Token")
            };
            List<UserVM> userList = await _userService.ReadUserList(readUserDto);
            return View(userList);
        }

    }
}

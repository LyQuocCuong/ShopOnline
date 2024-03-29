﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using ShopOnline.WebAdmin.Services;
using ShopOnline.Models.System.User.Dto;
using ShopOnline.Utilities.Consts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ShopOnline.Helpers.ShopOnlineApi;

namespace ShopOnline.WebAdmin.Controllers
{
    /// <summary>
    /// DON"T APPLY BASECONTROLLER
    /// </summary>
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<LoginController> _logger;
        private readonly IUserService _userService;

        public LoginController(IConfiguration configuration, ILogger<LoginController> logger,
                               IUserService userService)
        {
            _configuration = configuration;
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove(SystemValue.TOKEN_NAME);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginInfoDto loginInfoDto)
        {
            if (!ModelState.IsValid)
                return View(loginInfoDto);
            SOApiResult<string> resultGetToken = await _userService.GetToken(loginInfoDto);
            if (resultGetToken.IsSucceed && !string.IsNullOrEmpty(resultGetToken.ReturnedData))
            {
                string token = resultGetToken.ReturnedData;
                ClaimsPrincipal userPrincipal = this.ValidateToken(token);
                //cookie
                var authProp = new AuthenticationProperties()
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(SystemValue.TIMELIFE_COOKIE_MINUTES),
                    IsPersistent = true,
                };

                //Save cookie to Browser - IMPORTANT
                //The final step validate CookieAuthen
                await HttpContext.SignInAsync(
                                CookieAuthenticationDefaults.AuthenticationScheme,
                                userPrincipal,
                                authProp);

                HttpContext.Session.SetString(SystemValue.TOKEN_NAME, token);

                return RedirectToAction("Index", "Home");
            }
            //Log Here
            ModelState.AddModelError("Exception", resultGetToken.Message);
            return View();
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

    }
}

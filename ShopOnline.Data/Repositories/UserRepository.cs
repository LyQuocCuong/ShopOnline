using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopOnline.Data.Entities;
using ShopOnline.Data.Repositories.Definition;
using ShopOnline.Dto.System.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Repositories
{
    public class UserRepository : AbstractRepository<S_USER>
    {
        public UserRepository(ShopOnlineRepository repository) : base(repository)
        {
        }

        public async Task<bool> IsSucceedLogin(LoginRequestDto loginRequestDto)
        {
            S_USER user = await Repository.API_UserManager.FindByNameAsync(loginRequestDto.Username);
            if (user == null) return false;
            SignInResult resultLogin = await Repository.API_SignInManager
                                                .PasswordSignInAsync(
                                                        user,
                                                        loginRequestDto.Password,
                                                        loginRequestDto.IsRemember,
                                                        false);
            return resultLogin.Succeeded;
        }

        public async Task<string> GenerateJWT(string username)
        {
            S_USER user = await Repository.API_UserManager.FindByNameAsync(username);
            if (user == null) return "";
            List<string> roleNameList = (List<string>)await Repository.API_UserManager.GetRolesAsync(user);

            Claim[] userInfo = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim(ClaimTypes.Role, string.Join(",", roleNameList))
            };

            var secrectKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Repository.Configuration["Token:Secrect_Key"]));
            var signatureFormat = new SigningCredentials(secrectKey, SecurityAlgorithms.HmacSha256);

            var tokenInfo = new JwtSecurityToken(
                Repository.Configuration["Token:Issuer"],
                Repository.Configuration["Token:Issuer"],
                userInfo,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signatureFormat);
            return new JwtSecurityTokenHandler().WriteToken(tokenInfo);
        }

        public async Task<bool> Register(RegisterRequestDto registerRequestDto)
        {
            S_USER newUser = new S_USER()
            {
                Id = Guid.NewGuid(),
                UserName = registerRequestDto.Username,
                PasswordHash = registerRequestDto.Password,
                FULL_NAME = registerRequestDto.Fullname,
                DOB = registerRequestDto.DOB,
                STATUS = Enums.UserStatus.Activated,
                IS_DELETED = false,
            };
            var result = await Repository.API_UserManager.CreateAsync(newUser, registerRequestDto.Password);
            return result.Succeeded;
        }
    }
}

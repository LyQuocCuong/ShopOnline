using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopOnline.Data.Entities;
using ShopOnline.Data.Repositories.Definition;
using ShopOnline.Dto.System.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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

        public async Task<bool> IsSucceedLogin(LoginUserDto loginUserDto)
        {
            S_USER user = await Repository.SysApi_UserManager.FindByNameAsync(loginUserDto.Username);
            if (user == null) return false;
            SignInResult resultLogin = await Repository.SysApi_SignInManager
                                                .PasswordSignInAsync(
                                                        user,
                                                        loginUserDto.Password,
                                                        loginUserDto.IsRemember,
                                                        false);
            return resultLogin.Succeeded;
        }

        public async Task<string> GenerateJWT(string username)
        {
            S_USER user = await Repository.SysApi_UserManager.FindByNameAsync(username);
            if (user == null) return "";
            List<string> roleNameList = (List<string>)await Repository.SysApi_UserManager.GetRolesAsync(user);

            Claim[] userInfo = new[]
            {
                new Claim(ClaimTypes.Name, username),
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

        public async Task<bool> CreateUser(CreateUserDto createUserDto)
        {
            S_USER newUser = new S_USER()
            {
                Id = Guid.NewGuid(),
                UserName = createUserDto.Username,
                PasswordHash = createUserDto.RawPassword,
                FULL_NAME = createUserDto.Fullname,
                DOB = createUserDto.DOB,
                STATUS = Enums.UserStatus.Activated,
                IS_DELETED = false,
            };
            var result = await Repository.SysApi_UserManager.CreateAsync(newUser, createUserDto.RawPassword);
            return result.Succeeded;
        }

        public async Task<bool> UpdateUser(UpdateUserDto updateUserDto)
        {
            S_USER existingUser = DataSet.FirstOrDefault(u => u.Id == updateUserDto.UserId);
            if (existingUser != null)
            {
                existingUser.FULL_NAME = updateUserDto.FullName;
                existingUser.DOB = updateUserDto.DOB;
                existingUser.Email = updateUserDto.Email;
                var result = await Repository.SysApi_UserManager.UpdateAsync(existingUser);
                return result.Succeeded;
            };
            return false;
        }

        public async Task<bool> DeleteUser(Guid userId)
        {
            S_USER existingUser = DataSet.FirstOrDefault(u => u.Id == userId);
            if (existingUser != null)
            {
                existingUser.IS_DELETED = true;
                var result = await Repository.SysApi_UserManager.UpdateAsync(existingUser);
                return result.Succeeded;
            };
            return false;
        }

        public List<UserVM> ReadUserList()
        {
            List<UserVM> userList = new List<UserVM>();
            try
            {
                userList = DataSet.Where(u => !u.IS_DELETED)
                                  .Select(u => new UserVM()
                                  {
                                      UserId = u.Id,
                                      Username = u.UserName,
                                      FullName = u.FULL_NAME,
                                      DOB = u.DOB,
                                      Email = u.Email,
                                      Status = u.STATUS,
                                  }).ToList();
            }
            catch (Exception ex)
            {

            }
            return userList;
        }
    }
}

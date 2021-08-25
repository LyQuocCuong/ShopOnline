using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopOnline.Data.Entities;
using ShopOnline.Data.Repositories.Definition;
using ShopOnline.Models.System.User;
using ShopOnline.Models.System.User.Dto;
using ShopOnline.Utilities.Consts;
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

        public async Task<bool> IsSucceedLogin(LoginInfoDto loginInfoDto)
        {
            S_USER user = await Repository.SysApi_UserManager.FindByNameAsync(loginInfoDto.UserName);
            if (user == null)
            {
                //Log Here
                return false;
            }
            SignInResult resultLogin = await Repository.SysApi_SignInManager
                                                .PasswordSignInAsync(
                                                        user,
                                                        loginInfoDto.Password,
                                                        loginInfoDto.IsRemember,
                                                        false);
            return resultLogin.Succeeded;
        }

        public async Task<string> GenerateToken(string userName)
        {
            S_USER user = await Repository.SysApi_UserManager.FindByNameAsync(userName);
            if (user == null)
            {
                //Log Here
                return "";
            };
            List<string> roleNameList = (List<string>)await Repository.SysApi_UserManager.GetRolesAsync(user);

            Claim[] userInfo = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, string.Join(",", roleNameList))
            };

            var secrectKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Repository.Configuration["Token:Secrect_Key"]));
            var signatureFormat = new SigningCredentials(secrectKey, SecurityAlgorithms.HmacSha256);

            var tokenInfo = new JwtSecurityToken(
                Repository.Configuration["Token:Issuer"],
                Repository.Configuration["Token:Issuer"],
                userInfo,
                expires: DateTime.Now.AddMinutes(SystemConst.TIMELIFE_TOKEN_MINUTES),
                signingCredentials: signatureFormat);
            return new JwtSecurityTokenHandler().WriteToken(tokenInfo);
        }

        private async Task<bool> IsDuplicatedInfo(CreateUserDto userDto)
        {
            return await Repository.SysApi_UserManager.FindByNameAsync(userDto.Username) != null ||
                   await Repository.SysApi_UserManager.FindByEmailAsync(userDto.Email) != null;
        }

        public async Task<bool> Create(CreateUserDto createUserDto)
        {
            if (await IsDuplicatedInfo(createUserDto) == false)
            {
                S_USER newUser = new S_USER()
                {
                    Id = Guid.NewGuid(),
                    UserName = createUserDto.Username,
                    PasswordHash = createUserDto.RawPassword,
                    Email = createUserDto.Email,
                    FULL_NAME = createUserDto.FullName,
                    DOB = createUserDto.DOB,
                    STATUS = Enums.UserStatus.Activated,
                    IS_DELETED = false,
                };
                var result = await Repository.SysApi_UserManager.CreateAsync(newUser, createUserDto.RawPassword);
                return result.Succeeded;
            }
            return false;
        }

        public async Task<bool> UpdateBasicInfo(UserBasicInfoDto basicInfoDto)
        {
            S_USER existingUser = DataSet.FirstOrDefault(u => u.Id == basicInfoDto.UserId);
            if (existingUser != null)
            {
                existingUser.FULL_NAME = basicInfoDto.FullName;
                existingUser.DOB = basicInfoDto.DOB;
                existingUser.Email = basicInfoDto.Email;
                var result = await Repository.SysApi_UserManager.UpdateAsync(existingUser);
                return result.Succeeded;
            };
            return false;
        }

        public async Task<bool> UpdatePassword(Guid userId, string newPassword)
        {
            S_USER existingUser = DataSet.FirstOrDefault(u => u.Id == userId);
            if (existingUser != null)
            {
                existingUser.PasswordHash = newPassword;
                var result = await Repository.SysApi_UserManager.UpdateAsync(existingUser);
                return result.Succeeded;
            };
            return false;
        }

        public async Task<bool> Delete(Guid userId)
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

        public async Task<UserDto> GetByUserId(Guid userId)
        {
            S_USER user = await Repository.SysApi_UserManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                //Log Here
                return new UserDto();
            }
            UserDto userDto = new UserDto()
            {
                UserId = user.Id,
                FullName = user.FULL_NAME,
                Username = user.UserName,
                DOB = user.DOB,
                Email = user.Email,
                Status = user.STATUS
            };
            return userDto;
        }

        public List<UserDto> GetUserList(ReadUserDto readUserDto)
        {
            List<UserDto> userList = new List<UserDto>();
            try
            {
                userList = DataSet.Where(u => !u.IS_DELETED)
                                  .OrderBy(u => u.UserName)
                                  .Select(u => new UserDto()
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

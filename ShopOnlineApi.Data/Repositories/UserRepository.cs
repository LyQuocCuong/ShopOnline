using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopOnline.Data.Entities;
using ShopOnline.Data.Repositories.Definition;
using ShopOnline.Helpers.ShopOnlineApi;
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

        public async Task<SOApiResult<bool>> IsSucceedLogin(LoginInfoDto loginInfoDto)
        {
            S_USER user = await Repository.SysApi_UserManager.FindByNameAsync(loginInfoDto.UserName);
            if (user == null)
            {
                //Log Here
                return new SOApiErrorResult<bool>("User not found");
            }
            SignInResult resultLogin = await Repository.SysApi_SignInManager
                                                .PasswordSignInAsync(
                                                        user,
                                                        loginInfoDto.Password,
                                                        loginInfoDto.IsRemember,
                                                        false);
            if (resultLogin.Succeeded)
            {
                return new SOApiSuccessResult<bool>();
            }
            return new SOApiErrorResult<bool>("Login failed");
        }

        public async Task<SOApiResult<string>> GenerateToken(string userName)
        {
            S_USER user = await Repository.SysApi_UserManager.FindByNameAsync(userName);
            if (user == null)
            {
                //Log Here
                return new SOApiErrorResult<string>("User not found");
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
                expires: DateTime.Now.AddMinutes(SystemValue.TIMELIFE_TOKEN_MINUTES),
                signingCredentials: signatureFormat);
            return new SOApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(tokenInfo));
        }

        public SOApiResult<bool> VerifyUserInfo(UserDto userDto)
        {
            if (this.DataSet.FirstOrDefault(u => !string.IsNullOrEmpty(userDto.Username) && u.UserName == userDto.Username && 
                                                (userDto.UserId == Guid.Empty || u.Id != userDto.UserId)) != null)
            {
                return new SOApiErrorResult<bool>("Username is existing");
            }
            if (this.DataSet.FirstOrDefault(u => !string.IsNullOrEmpty(userDto.Email) && u.Email == userDto.Email &&
                                                (userDto.UserId != Guid.Empty ? u.Id != userDto.UserId : true)) != null)
            {
                return new SOApiErrorResult<bool>("Email is existing");
            }
            return new SOApiSuccessResult<bool>();
        }

        public async Task<SOApiResult<bool>> Create(CreateUserDto createUserDto)
        {
            S_USER newUser = new S_USER()
            {
                Id = Guid.NewGuid(),
                UserName = createUserDto.UserName,
                PasswordHash = createUserDto.RawPassword,
                Email = createUserDto.Email,
                FULL_NAME = createUserDto.FullName,
                DOB = createUserDto.DOB,
                STATUS = Enums.UserStatus.Activated,
                IS_DELETED = false,
            };
            var result = await Repository.SysApi_UserManager.CreateAsync(newUser, createUserDto.RawPassword);
            if (result.Succeeded)
            {
                return new SOApiSuccessResult<bool>();
            }
            return new SOApiErrorResult<bool>("Create-User failed " + string.Join("", result.Errors.Select(e => e.Description).ToList()));
        }

        public async Task<SOApiResult<bool>> UpdateBasicInfo(UserBasicInfoDto basicInfoDto)
        {
            S_USER existingUser = DataSet.FirstOrDefault(u => !u.IS_DELETED && u.Id == basicInfoDto.UserId);
            if (existingUser != null)
            {
                existingUser.FULL_NAME = basicInfoDto.FullName;
                existingUser.DOB = basicInfoDto.DOB;
                existingUser.Email = basicInfoDto.Email;
                var result = await Repository.SysApi_UserManager.UpdateAsync(existingUser);
                if (result.Succeeded)
                {
                    return new SOApiSuccessResult<bool>();
                }
                return new SOApiErrorResult<bool>("Update-User failed " + string.Join("", result.Errors.Select(e => e.Description).ToList()));
            };
            return new SOApiErrorResult<bool>("User not found");
        }

        public async Task<SOApiResult<bool>> UpdatePassword(Guid userId, string newPassword)
        {
            S_USER existingUser = DataSet.FirstOrDefault(u => u.Id == userId);
            if (existingUser != null)
            {
                existingUser.PasswordHash = newPassword;
                var result = await Repository.SysApi_UserManager.UpdateAsync(existingUser);
                if (result.Succeeded)
                {
                    return new SOApiSuccessResult<bool>();
                }
                return new SOApiErrorResult<bool>("Update-Password-User failed");
            };
            return new SOApiErrorResult<bool>("User not found");
        }

        public async Task<SOApiResult<bool>> Delete(Guid userId)
        {
            S_USER existingUser = DataSet.FirstOrDefault(u => u.Id == userId);
            if (existingUser != null)
            {
                existingUser.IS_DELETED = true;
                var result = await Repository.SysApi_UserManager.UpdateAsync(existingUser);
                if (result.Succeeded)
                {
                    return new SOApiSuccessResult<bool>();
                }
                return new SOApiErrorResult<bool>("Delete-User failed");
            };
            return new SOApiErrorResult<bool>("User not found");
        }

        public async Task<SOApiResult<UserDto>> GetByUserId(Guid userId)
        {
            S_USER user = await Repository.SysApi_UserManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                //Log Here
                return new SOApiErrorResult<UserDto>("User not found");
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
            return new SOApiSuccessResult<UserDto>(userDto);
        }

        public SOApiResult<List<UserDto>> GetUserList(ReadUserDto readUserDto)
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
            return new SOApiSuccessResult<List<UserDto>>(userList);
        }
    }
}

using ShopOnline.Helpers.ShopOnlineApi;
using ShopOnline.Models.System.User;
using ShopOnline.Models.System.User.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.WebAdmin.Services
{
    public interface IUserService
    {
        Task<SOApiResult<string>> GetToken(LoginInfoDto loginInfoDto);
        Task<SOApiResult<bool>> Create(CreateUserDto createUserDto);
        Task<SOApiResult<bool>> UpdateBasicInfo(UserBasicInfoDto basicInfoDto);
        Task<SOApiResult<bool>> UpdatePassword(Guid userId, string newPassword);
        Task<SOApiResult<List<UserDto>>> GetUserList(ReadUserDto readUserDto);
        Task<SOApiResult<UserDto>> GetByUserId(Guid userId);
    }
}

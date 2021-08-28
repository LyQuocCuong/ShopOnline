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
        Task<string> GetToken(LoginInfoDto loginInfoDto);
        Task<bool> Create(CreateUserDto createUserDto);
        Task<bool> UpdateBasicInfo(UserBasicInfoDto basicInfoDto);
        Task<bool> UpdatePassword(Guid userId, string newPassword);
        Task<List<UserDto>> GetUserList(ReadUserDto readUserDto);
        Task<UserDto> GetByUserId(Guid userId);
    }
}

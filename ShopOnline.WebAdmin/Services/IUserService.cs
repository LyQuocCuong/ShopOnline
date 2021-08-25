using ShopOnline.Models.System.User;
using ShopOnline.Models.System.User.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.AppAdmin.Services
{
    public interface IUserService
    {
        Task<string> GenerateTokenByLoginInfo(LoginRequestDto loginRequestDto);
        Task<bool> Create(string token, CreateUserDto createUserDto);
        Task<bool> UpdateBasicInfo(string token, UserBasicInfoDto basicInfoDto);
        Task<bool> UpdatePassword(string token, Guid userId, string newPassword);
        Task<List<UserDto>> GetUserList(string token, ReadUserDto readUserDto);
        Task<UserDto> GetByUserId(string token, Guid userId);
    }
}

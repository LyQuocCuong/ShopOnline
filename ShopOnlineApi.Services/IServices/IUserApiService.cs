using ShopOnline.Models.System.User;
using ShopOnline.Models.System.User.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Services.IServices
{
    public interface IUserApiService
    {
        Task<bool> IsSucceedLogin(LoginInfoDto loginInfoDto);
        Task<string> GenerateToken(string userName);
        Task<bool> Create(CreateUserDto createUserDto);
        Task<bool> UpdateBasicInfo(UserBasicInfoDto basicInfoDto);
        Task<bool> UpdatePassword(Guid userId, string newPassword);
        Task<bool> Delete(Guid userId);
        List<UserDto> GetUserList(ReadUserDto readUserDto);
        Task<UserDto> GetByUserId(Guid userId);
    }
}

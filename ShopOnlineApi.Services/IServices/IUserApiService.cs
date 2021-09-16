using ShopOnline.Helpers.ShopOnlineApi;
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
        Task<SOApiResult<bool>> IsSucceedLogin(LoginInfoDto loginInfoDto);
        Task<SOApiResult<string>> GenerateToken(string userName);
        Task<SOApiResult<bool>> Create(CreateUserDto createUserDto);
        Task<SOApiResult<bool>> UpdateBasicInfo(UserBasicInfoDto basicInfoDto);
        Task<SOApiResult<bool>> UpdatePassword(Guid userId, string newPassword);
        Task<SOApiResult<bool>> Delete(Guid userId);
        SOApiResult<List<UserDto>> GetUserList(ReadUserDto readUserDto);
        Task<SOApiResult<UserDto>> GetByUserId(Guid userId);
    }
}

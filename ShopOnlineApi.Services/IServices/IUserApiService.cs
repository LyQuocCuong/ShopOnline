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
        Task<bool> IsSucceedLogin(LoginRequestDto loginUserDto);
        Task<string> GenerateToken(LoginRequestDto loginUserDto);
        Task<bool> CreateUser(CreateUserDto createUserDto);
        Task<bool> UpdateUser(UpdateUserDto updateUserDto);
        Task<bool> DeleteUser(Guid userId);
        List<UserDto> ReadUserList(ReadUserDto readUserDto);
    }
}

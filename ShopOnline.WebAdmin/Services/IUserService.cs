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
        public Task<bool> CreateUser(CreateUserDto createUserDto);
        public Task<bool> UpdateUser(UpdateUserDto updateUserDto);
        public Task<bool> DeleteUser(Guid userId);
        public Task<List<UserDto>> ReadUserList(ReadUserDto readUserDto);
    }
}

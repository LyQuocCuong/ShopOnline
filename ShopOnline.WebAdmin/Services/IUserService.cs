using ShopOnline.Dto.System.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.AppAdmin.Services
{
    public interface IUserService
    {
        Task<string> Authenticate(LoginUserDto loginRequestDto);
        public Task<bool> CreateUser(CreateUserDto createUserDto);
        public Task<bool> UpdateUser(UpdateUserDto updateUserDto);
        public Task<bool> DeleteUser(Guid userId);
        public Task<List<UserVM>> ReadUserList();
    }
}

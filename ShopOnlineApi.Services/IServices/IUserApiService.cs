using ShopOnline.Dto.System.User;
using ShopOnline.Models.System.User.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Services.IServices
{
    public interface IUserApiService
    {
        public Task<string> GetJWT(LoginUserDto loginUserDto);
        public Task<bool> CreateUser(CreateUserDto createUserDto);
        public Task<bool> UpdateUser(UpdateUserDto updateUserDto);
        public Task<bool> DeleteUser(Guid userId);
        public List<UserVM> ReadUserList(ReadUserDto readUserDto);
    }
}

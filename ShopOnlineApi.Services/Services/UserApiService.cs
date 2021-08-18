using ShopOnline.Data.Repositories.Definition;
using ShopOnline.Models.System.User;
using ShopOnline.Models.System.User.Dto;
using ShopOnline.Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Services.Services
{
    public class UserApiService : IUserApiService
    {
        private readonly ShopOnlineRepository _repository;

        public UserApiService(ShopOnlineRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> IsSucceedLogin(LoginRequestDto loginUserDto)
        {
            return await _repository.SUSER_REPOSITORY.IsSucceedLogin(loginUserDto);
        }

        public async Task<string> GenerateToken(LoginRequestDto loginUserDto)
        {
            return await _repository.SUSER_REPOSITORY.GenerateToken(loginUserDto.Username);
        }

        public async Task<bool> CreateUser(CreateUserDto createUserDto)
        {
            return await _repository.SUSER_REPOSITORY.CreateUser(createUserDto);
        }

        public async Task<bool> UpdateUser(UpdateUserDto updateUserDto)
        {
            return await _repository.SUSER_REPOSITORY.UpdateUser(updateUserDto);
        }

        public async Task<bool> DeleteUser(Guid userId)
        {
            return await _repository.SUSER_REPOSITORY.DeleteUser(userId);
        }

        public List<UserDto> ReadUserList(ReadUserDto readUserDto)
        {
            return _repository.SUSER_REPOSITORY.ReadUserList(readUserDto);
        }
    }
}

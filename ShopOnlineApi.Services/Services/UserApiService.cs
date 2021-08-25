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

        public async Task<bool> IsSucceedLogin(LoginInfoDto loginInfoDto)
        {
            return await _repository.SUSER_REPOSITORY.IsSucceedLogin(loginInfoDto);
        }

        public async Task<string> GenerateToken(string userName)
        {
            return await _repository.SUSER_REPOSITORY.GenerateToken(userName);
        }

        public async Task<bool> Create(CreateUserDto createUserDto)
        {
            return await _repository.SUSER_REPOSITORY.Create(createUserDto);
        }

        public async Task<bool> UpdateBasicInfo(UserBasicInfoDto basicInfoDto)
        {
            return await _repository.SUSER_REPOSITORY.UpdateBasicInfo(basicInfoDto);
        }

        public async Task<bool> UpdatePassword(Guid userId, string newPassword)
        {
            return await _repository.SUSER_REPOSITORY.UpdatePassword(userId, newPassword);
        }

        public async Task<bool> Delete(Guid userId)
        {
            return await _repository.SUSER_REPOSITORY.Delete(userId);
        }

        public List<UserDto> GetUserList(ReadUserDto readUserDto)
        {
            return _repository.SUSER_REPOSITORY.GetUserList(readUserDto);
        }

        public async Task<UserDto> GetByUserId(Guid userId)
        {
            return await _repository.SUSER_REPOSITORY.GetByUserId(userId);
        }
    }
}

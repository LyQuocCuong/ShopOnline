using ShopOnline.Data.Repositories.Definition;
using ShopOnline.Helpers.ShopOnlineApi;
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

        public async Task<SOApiResult<bool>> IsSucceedLogin(LoginInfoDto loginInfoDto)
        {
            return await _repository.SUSER_REPOSITORY.IsSucceedLogin(loginInfoDto);
        }

        public async Task<SOApiResult<string>> GenerateToken(string userName)
        {
            return await _repository.SUSER_REPOSITORY.GenerateToken(userName);
        }

        public async Task<SOApiResult<bool>> Create(CreateUserDto createUserDto)
        {
            SOApiResult<bool> result = _repository.SUSER_REPOSITORY.VerifyUserInfo(new UserDto()
            {
                Username = createUserDto.UserName,
                Email = createUserDto.Email
            });
            if (result.IsSucceed)
            {
                return await _repository.SUSER_REPOSITORY.Create(createUserDto);
            }
            return result;
        }

        public async Task<SOApiResult<bool>> UpdateBasicInfo(UserBasicInfoDto basicInfoDto)
        {
            SOApiResult<bool> result = _repository.SUSER_REPOSITORY.VerifyUserInfo(new UserDto()
            {
                UserId = basicInfoDto.UserId,
                Email = basicInfoDto.Email
            });
            if (result.IsSucceed)
            {
                return await _repository.SUSER_REPOSITORY.UpdateBasicInfo(basicInfoDto);
            }
            return result;
        }

        public async Task<SOApiResult<bool>> UpdatePassword(Guid userId, string newPassword)
        {
            return await _repository.SUSER_REPOSITORY.UpdatePassword(userId, newPassword);
        }

        public async Task<SOApiResult<bool>> Delete(Guid userId)
        {
            return await _repository.SUSER_REPOSITORY.Delete(userId);
        }

        public SOApiResult<List<UserDto>> GetUserList(ReadUserDto readUserDto)
        {
            return _repository.SUSER_REPOSITORY.GetUserList(readUserDto);
        }

        public async Task<SOApiResult<UserDto>> GetByUserId(Guid userId)
        {
            return await _repository.SUSER_REPOSITORY.GetByUserId(userId);
        }
    }
}

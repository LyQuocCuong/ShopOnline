using ShopOnline.Data.Repositories.Definition;
using ShopOnline.Dto.System.User;
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

        /// <summary>
        /// Return a token if login succeed
        /// </summary>
        /// <returns>a token</returns>
        public async Task<string> GetJWT(LoginUserDto loginUserDto)
        {
            string token = "";
            if (await _repository.SUSER_REPOSITORY.IsSucceedLogin(loginUserDto) == true)
            {
                token = await _repository.SUSER_REPOSITORY.GenerateJWT(loginUserDto.Username);
            }
            return token;
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

        public List<UserVM> ReadUserList()
        {
            return _repository.SUSER_REPOSITORY.ReadUserList();
        }
    }
}

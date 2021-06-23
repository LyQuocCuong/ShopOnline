using ShopOnline.Data.Repositories.Definition;
using ShopOnline.Dto.System.User;
using ShopOnline.Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Services.Services
{
    public class UserPublicService : IUserPublicService
    {
        private readonly ShopOnlineRepository _repository;

        public UserPublicService(ShopOnlineRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Return a token if login succeed
        /// </summary>
        /// <param name="loginRequestDto"></param>
        /// <returns>a token</returns>
        public async Task<string> Login(LoginRequestDto loginRequestDto)
        {
            string token = "";
            if (await _repository.SUSER_REPOSITORY.IsSucceedLogin(loginRequestDto) == true)
            {
                token = await _repository.SUSER_REPOSITORY.GenerateJWT(loginRequestDto.Username);
            }
            return token;
        }

        public async Task<bool> Register(RegisterRequestDto registerRequestDto)
        {
            return await _repository.SUSER_REPOSITORY.Register(registerRequestDto);
        }
    }
}

using ShopOnline.Dto.System.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Services.IServices
{
    public interface IUserPublicService
    {
        public Task<string> Login(LoginRequestDto loginRequestDto);
        public Task<bool> Register(RegisterRequestDto registerRequestDto);
    }
}

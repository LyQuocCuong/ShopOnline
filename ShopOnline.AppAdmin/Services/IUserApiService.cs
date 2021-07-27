using ShopOnline.Dto.System.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.AppAdmin.Services
{
    public interface IUserApiService
    {
        Task<string> Authenticate(LoginRequestDto loginRequestDto);
    }
}

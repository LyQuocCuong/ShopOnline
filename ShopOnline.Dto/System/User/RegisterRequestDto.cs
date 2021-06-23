using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Dto.System.User
{
    public class RegisterRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public DateTime DOB { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Models.System.User.Dto
{
    public class LoginInfoDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }
}

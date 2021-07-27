using ShopOnline.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Dto.System.User
{
    public class UserViewDto
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public DateTime DOB { get; set; }
        public UserStatus Status { get; set; }
    }
}

﻿using ShopOnline.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Models.System.User.Dto
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public UserStatus Status { get; set; }
    }
}

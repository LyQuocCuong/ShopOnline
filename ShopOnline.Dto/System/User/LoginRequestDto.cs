﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Dto.System.User
{
    public class LoginRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }
}
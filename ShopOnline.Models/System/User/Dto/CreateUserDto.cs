using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopOnline.Models.System.User.Dto
{
    public class CreateUserDto
    {
        public string Username { get; set; }
        public string RawPassword { get; set; }
        public string ConfirmedRawPassword { get; set; }
        public string Fullname { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
    }
}

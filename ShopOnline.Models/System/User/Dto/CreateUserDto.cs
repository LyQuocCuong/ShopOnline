using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopOnline.Models.System.User.Dto
{
    public class CreateUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public string UserName { get; set; }
        public string RawPassword { get; set; }
        public string ConfirmedRawPassword { get; set; }    
    }
}

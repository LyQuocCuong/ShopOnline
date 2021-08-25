using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopOnline.Models.System.User.Dto
{
    public class CreateUserDto
    {
        public string FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string RawPassword { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmedRawPassword { get; set; }    
    }
}

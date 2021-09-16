using FluentValidation;
using ShopOnline.Models.System.User.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Models.System.User.Validator
{
    public class LoginInfoValidator : AbstractValidator<LoginInfoDto>
    {
        public LoginInfoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.IsRemember);
        }
    }
}

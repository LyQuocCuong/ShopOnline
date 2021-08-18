using FluentValidation;
using ShopOnline.Models.System.User.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Models.System.User.Validator
{
    public class LoginUserValidator : AbstractValidator<LoginRequestDto>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.IsRemember);
        }
    }
}

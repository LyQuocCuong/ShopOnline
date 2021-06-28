using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Dto.System.User
{
    public class LoginRequestValidator : AbstractValidator<LoginRequestDto>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.IsRemember).NotEmpty();
        }
    }
}

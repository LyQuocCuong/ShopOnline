using FluentValidation;
using ShopOnline.Models.System.User.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Models.System.User.Validator
{
    public class UserBasicInfoValidator : AbstractValidator<UserBasicInfoDto>
    {
        public UserBasicInfoValidator()
        {
            RuleFor(user => user.FullName)
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(user => user.Email)
                .NotEmpty()
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Wrong format email"); //Regex

            RuleFor(user => user.DOB)
                .NotEmpty()
                .GreaterThan(DateTime.Now.AddYears(-80)).WithMessage("You're over 100 years");

        }
    }
}

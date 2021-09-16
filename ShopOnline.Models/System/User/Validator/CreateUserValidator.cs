using FluentValidation;
using ShopOnline.Models.System.User.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Models.System.User.Validator
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
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

            RuleFor(user => user.UserName)
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(user => user.RawPassword)
                .NotEmpty();
            //Password must have at least one non - alphanumeric.
            //Password must have at least one digit "0"-> "9"
            //Password must have at least one uppercase "A"-> "Z"

            RuleFor(user => user.ConfirmedRawPassword)
                .NotEmpty()
                .When(user => !string.IsNullOrEmpty(user.RawPassword))
                .Equal(user => user.RawPassword).WithMessage("Your confirmation password is wrong");

        }
    }
}

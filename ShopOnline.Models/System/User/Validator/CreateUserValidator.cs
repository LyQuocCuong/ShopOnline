using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Dto.System.User
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Fullname).NotEmpty();
            RuleFor(x => x.DOB).NotEmpty()
                .GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("You're over 100 years");
            
            //Regex
            RuleFor(x => x.Email).NotEmpty()
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Wrong formar email");
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.RawPassword).NotEmpty();
            RuleFor(x => x.ConfirmedRawPassword).NotEmpty();
            
            //Custom Rule
            RuleFor(x => x).Custom((request, context) =>
            {
                if (!string.IsNullOrEmpty(request.RawPassword) && 
                    request.RawPassword == request.ConfirmedRawPassword)
                {
                    context.AddFailure("Password mismatched");
                }
            });
        }
    }
}

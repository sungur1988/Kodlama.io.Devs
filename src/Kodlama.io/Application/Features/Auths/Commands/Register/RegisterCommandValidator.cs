using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.UserForRegisterDto.FirstName).NotEmpty();
            RuleFor(x=>x.UserForRegisterDto.LastName).NotEmpty();
            RuleFor(x => x.UserForRegisterDto.Password).NotEmpty();
            RuleFor(x => x.UserForRegisterDto.Password).MinimumLength(4);
            RuleFor(x => x.UserForRegisterDto.Email).NotEmpty();
            RuleFor(x => x.UserForRegisterDto.Email).EmailAddress();
        }
    }
}

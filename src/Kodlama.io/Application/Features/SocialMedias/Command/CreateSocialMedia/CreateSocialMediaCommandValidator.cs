using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Command.CreateSocialMedia
{
    public class CreateSocialMediaCommandValidator : AbstractValidator<CreateSocialMediaCommand>
    {
        public CreateSocialMediaCommandValidator()
        {
            RuleFor(x=>x.AppUserId).NotEmpty();
            RuleFor(x => x.AppUserId).GreaterThan(0);
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(5);
            RuleFor(x=>x.UrlAddress).NotEmpty();
        }
    }
}

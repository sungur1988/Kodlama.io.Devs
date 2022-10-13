using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Command.DeleteSocialMedia
{
    public class DeleteSocialMediaCommandValidator : AbstractValidator<DeleteSocialMediaCommand>
    {
        public DeleteSocialMediaCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.UrlAddress).NotEmpty();
        }
    }
}

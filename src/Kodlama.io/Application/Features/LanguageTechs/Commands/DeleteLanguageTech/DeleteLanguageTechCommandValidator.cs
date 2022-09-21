using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechs.Commands.DeleteLanguageTech
{
    public class DeleteLanguageTechCommandValidator : AbstractValidator<DeleteLanguageTechCommand>
    {
        public DeleteLanguageTechCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(2);
        }
    }
}

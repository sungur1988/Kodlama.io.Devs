using Application.Features.LanguageTechs.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechs.Commands.UpdateLanguageTech
{
    public record UpdateLanguageTechCommand(int Id,int ProgrammingLanguageId,string Name):IRequest<UpdatedLanguageTechDto>;
}

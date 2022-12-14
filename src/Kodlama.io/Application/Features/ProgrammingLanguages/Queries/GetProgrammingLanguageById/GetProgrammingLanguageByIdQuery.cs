using Application.Features.ProgrammingLanguages.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguageById
{
    public record GetProgrammingLanguageByIdQuery(int Id) : IRequest<GetByIdProgrammingLanguageDto>;
    
}

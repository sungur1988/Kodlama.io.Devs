using Application.Features.ProgrammingLanguages.Models;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguageByDynamic
{
    public record GetListProgrammingLanguageByDynamicQuery(PageRequest PageRequest,Dynamic Dynamic) : IRequest<ProgrammingLanguageListModel>;
}

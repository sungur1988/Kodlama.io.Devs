using Application.Features.LanguageTechs.Models;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechs.Queries.GetLanguageTechByDynamic
{
    public record GetLanguageTechByDynamicQuery(Dynamic Dynamic,PageRequest PageRequest) : IRequest<LanguageTechListModel>;
}

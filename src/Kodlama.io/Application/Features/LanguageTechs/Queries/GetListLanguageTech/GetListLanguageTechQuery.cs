using Application.Features.LanguageTechs.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechs.Queries.GetListLanguageTech
{
    public record GetListLanguageTechQuery(PageRequest PageRequest) : IRequest<LanguageTechListModel>;
}

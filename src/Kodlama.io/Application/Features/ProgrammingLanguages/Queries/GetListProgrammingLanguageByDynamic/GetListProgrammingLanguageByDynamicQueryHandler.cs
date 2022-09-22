using Application.Features.ProgrammingLanguages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguageByDynamic
{
    public class GetListProgrammingLanguageByDynamicQueryHandler : IRequestHandler<GetListProgrammingLanguageByDynamicQuery, ProgrammingLanguageListModel>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;

        public GetListProgrammingLanguageByDynamicQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageByDynamicQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProgrammingLanguage> programmingLanguages = await _programmingLanguageRepository
                                                                            .GetListByDynamicAsync(
                                                                                                    request.Dynamic,
                                                                                                    index: request.PageRequest.Page,
                                                                                                    size: request.PageRequest.PageSize,
                                                                                                    include: x => x.Include(y => y.LanguageTechs));
            ProgrammingLanguageListModel mappedModel = _mapper.Map<ProgrammingLanguageListModel>(programmingLanguages);

            return mappedModel;
        }
    }
}

using Application.Features.LanguageTechs.Models;
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

namespace Application.Features.LanguageTechs.Queries.GetListLanguageTech
{
    public class GetListLanguageTechQueryHandler : IRequestHandler<GetListLanguageTechQuery, LanguageTechListModel>
    {
        private readonly ILanguageTechRepository _languageTechRepository;
        private readonly IMapper _mapper;

        public GetListLanguageTechQueryHandler(ILanguageTechRepository languageTechRepository, IMapper mapper)
        {
            _languageTechRepository = languageTechRepository;
            _mapper = mapper;
        }

        public async Task<LanguageTechListModel> Handle(GetListLanguageTechQuery request, CancellationToken cancellationToken)
        {
            IPaginate<LanguageTech> entities = await _languageTechRepository.GetListAsync(
                                                                                            index: request.PageRequest.Page, 
                                                                                            size: request.PageRequest.PageSize, 
                                                                                            include: x => x.Include(y => y.ProgrammingLanguage));
            LanguageTechListModel mappedModel = _mapper.Map<LanguageTechListModel>(entities);

            return mappedModel;
        }
    }
}

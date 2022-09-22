using Application.Features.LanguageTechs.Dtos;
using Application.Features.LanguageTechs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechs.Queries.GetLanguageTechById
{
    public class GetLangugageTechByIdQueryHandler : IRequestHandler<GetLangugageTechByIdQuery, GetLanguageTechByIdDto>
    {
        private readonly ILanguageTechRepository _languageTechRepository;
        private readonly IMapper _mapper;
        private readonly LanguageTechBusinessRules _languageTechBusinessRules;

        public GetLangugageTechByIdQueryHandler(ILanguageTechRepository languageTechRepository, IMapper mapper, LanguageTechBusinessRules languageTechBusinessRules)
        {
            _languageTechRepository = languageTechRepository;
            _mapper = mapper;
            _languageTechBusinessRules = languageTechBusinessRules;
        }

        public async Task<GetLanguageTechByIdDto> Handle(GetLangugageTechByIdQuery request, CancellationToken cancellationToken)
        {
            LanguageTech? entity = await _languageTechRepository.GetAsync(x => x.Id == request.Id);

            _languageTechBusinessRules.LanguageTechMustExistWhenRequested(entity);

            GetLanguageTechByIdDto mappedEntity = _mapper.Map<GetLanguageTechByIdDto>(entity);

            return mappedEntity;
        }
    }
}

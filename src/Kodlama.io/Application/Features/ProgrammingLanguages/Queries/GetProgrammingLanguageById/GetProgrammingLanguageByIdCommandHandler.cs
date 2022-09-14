using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguageById
{
    public class GetProgrammingLanguageByIdCommandHandler : IRequestHandler<GetProgrammingLanguageByIdQuery, GetByIdProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public GetProgrammingLanguageByIdCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }

        public async Task<GetByIdProgrammingLanguageDto> Handle(GetProgrammingLanguageByIdQuery request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage? entity = await _programmingLanguageRepository.GetAsync(x => x.Id == request.Id);

            _programmingLanguageBusinessRules.ProgrammingLanguageMustExistWhenRequested(entity);

            GetByIdProgrammingLanguageDto mappedEntity = _mapper.Map<GetByIdProgrammingLanguageDto>(entity);

            return mappedEntity;
        }
    }
}

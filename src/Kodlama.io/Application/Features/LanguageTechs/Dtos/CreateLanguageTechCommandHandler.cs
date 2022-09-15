using Application.Features.LanguageTechs.Commands.CreateLanguageTech;
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

namespace Application.Features.LanguageTechs.Dtos
{
    public class CreateLanguageTechCommandHandler : IRequestHandler<CreateLanguageTechCommand, CreatedLanguageTechDto>
    {
        private readonly ILanguageTechRepository _languageTechRepository;
        private readonly IMapper _mapper;
        private readonly LanguageTechBusinessRules _languageTechBusinessRules;

        public CreateLanguageTechCommandHandler(ILanguageTechRepository languageTechRepository, IMapper mapper, LanguageTechBusinessRules languageTechBusinessRules)
        {
            _languageTechRepository = languageTechRepository;
            _mapper = mapper;
            _languageTechBusinessRules = languageTechBusinessRules;
        }

        public async Task<CreatedLanguageTechDto> Handle(CreateLanguageTechCommand request, CancellationToken cancellationToken)
        {
            await _languageTechBusinessRules.ProgrammingLanguageCannotBeDuplicatedWhenInsertedOrUpdated(request.Name);

            LanguageTech entityToAdd =  _mapper.Map<LanguageTech>(request); 
            LanguageTech addedEntity = await _languageTechRepository.AddAsync(entityToAdd);
            CreatedLanguageTechDto mappedEntity = _mapper.Map<CreatedLanguageTechDto>(addedEntity);

            return mappedEntity;
        }
    }
}

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

namespace Application.Features.LanguageTechs.Commands.UpdateLanguageTech
{
    public class UpdateLanguageTechCommandHandler : IRequestHandler<UpdateLanguageTechCommand, UpdatedLanguageTechDto>
    {
        private readonly ILanguageTechRepository _languageTechRepository;
        private readonly IMapper _mapper;
        private readonly LanguageTechBusinessRules _languageTechBusinessRules;

        public UpdateLanguageTechCommandHandler(ILanguageTechRepository languageTechRepository, IMapper mapper, LanguageTechBusinessRules languageTechBusinessRules)
        {
            _languageTechRepository = languageTechRepository;
            _mapper = mapper;
            _languageTechBusinessRules = languageTechBusinessRules;
        }

        public async Task<UpdatedLanguageTechDto> Handle(UpdateLanguageTechCommand request, CancellationToken cancellationToken)
        {
            await _languageTechBusinessRules.LanguageTechMustExistWhenUpdatedOrDeleted(request.Id);
            await _languageTechBusinessRules.LanguageTechCannotBeDuplicatedWhenInsertedOrUpdated(request.Name);

            LanguageTech entityToUpdate = _mapper.Map<LanguageTech>(request);
            LanguageTech updatedEntity = await _languageTechRepository.UpdateAsync(entityToUpdate);
            UpdatedLanguageTechDto mappedEntity = _mapper.Map<UpdatedLanguageTechDto>(updatedEntity);

            return mappedEntity;
        }
    }
}

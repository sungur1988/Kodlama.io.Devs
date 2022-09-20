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

namespace Application.Features.LanguageTechs.Commands.DeleteLanguageTech
{
    public class DeleteLanguageTechCommandHandler : IRequestHandler<DeleteLanguageTechCommand, DeletedLanguageTechDto>
    {
        private readonly ILanguageTechRepository _languageTechRepository;
        private readonly IMapper _mapper;
        private readonly LanguageTechBusinessRules _languageTechBusinessRules;

        public DeleteLanguageTechCommandHandler(ILanguageTechRepository languageTechRepository, IMapper mapper, LanguageTechBusinessRules languageTechBusinessRules)
        {
            _languageTechRepository = languageTechRepository;
            _mapper = mapper;
            _languageTechBusinessRules = languageTechBusinessRules;
        }

        public async Task<DeletedLanguageTechDto> Handle(DeleteLanguageTechCommand request, CancellationToken cancellationToken)
        {
            await _languageTechBusinessRules.LanguageTechMustExistWhenUpdatedOrDeleted(request.Id);

            LanguageTech entityToDelete = _mapper.Map<LanguageTech>(request);
            LanguageTech deletedEntity = await _languageTechRepository.DeleteAsync(entityToDelete);
            DeletedLanguageTechDto mappedEntity = _mapper.Map<DeletedLanguageTechDto>(deletedEntity);

            return mappedEntity;
        }
    }
}

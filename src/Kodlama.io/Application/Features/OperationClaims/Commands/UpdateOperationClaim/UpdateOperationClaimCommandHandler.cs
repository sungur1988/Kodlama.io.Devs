using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

        public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        async Task<UpdatedOperationClaimDto> IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimDto>.Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _operationClaimBusinessRules.OperationClaimNameCannotBeDuplicated(request.Name);
            await _operationClaimBusinessRules.OperationClaimMustBeExistWhenRequested(request.Id);

            OperationClaim entityToUpdate = _mapper.Map<OperationClaim>(request);
            OperationClaim updatedEntity = await _operationClaimRepository.UpdateAsync(entityToUpdate);
            UpdatedOperationClaimDto mappedEntity = _mapper.Map<UpdatedOperationClaimDto>(updatedEntity);

            return mappedEntity;
        }
    }
}

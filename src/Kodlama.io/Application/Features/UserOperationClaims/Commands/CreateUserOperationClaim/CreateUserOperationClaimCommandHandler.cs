using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, CreatedUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository,
                                                      IUserRepository userRepository, IOperationClaimRepository operationClaimRepository, 
                                                      IMapper mapper, 
                                                      UserOperationClaimBusinessRules userOperationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _userRepository = userRepository;
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _userOperationClaimBusinessRules.UserOperationClaimCannotBeExistWhenCreated(request.AppUserId, request.OperationClaimId);

            AppUser? appUser = await _userRepository.GetAsync(x=>x.Id==request.AppUserId);
            _userOperationClaimBusinessRules.UserShouldBeExistWhenRequested(appUser);

            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == request.OperationClaimId);
            _userOperationClaimBusinessRules.OperationClaimShouldBeExistWhenRequested(operationClaim);

            UserOperationClaim entityToAdd = _mapper.Map<UserOperationClaim>(request);
            UserOperationClaim addedEntity = await _userOperationClaimRepository.AddAsync(entityToAdd);

            return new CreatedUserOperationClaimDto { AppUser = $"{appUser.FirstName} {appUser.LastName}", OperationClaim = operationClaim.Name };
        }
    }
}

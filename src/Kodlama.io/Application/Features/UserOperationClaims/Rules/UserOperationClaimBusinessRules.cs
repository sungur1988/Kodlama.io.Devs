using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
        }
        public void UserShouldBeExistWhenRequested(AppUser? appUser)
        {
            if (appUser is null) throw new BusinessException("User should be exist when requested.");
        }
        public void OperationClaimShouldBeExistWhenRequested(OperationClaim? operationClaim)
        {
            if (operationClaim is null) throw new BusinessException("Operation claim should be exist when requested.");
        }
        public async Task UserOperationClaimCannotBeExistWhenCreated(int appUserId,int operationClaimId)
        {
            UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(x => x.UserId == appUserId && x.OperationClaimId == operationClaimId);
            if (userOperationClaim is not null) throw new BusinessException("This operation claim already added");
        }
        public async Task UserOperationClaimSholdBeExistWhenRequested(int appUserId,int operationClaimId)
        {
            IPaginate<UserOperationClaim>? userOperationClaims = await _userOperationClaimRepository.GetListAsync(x => x.UserId == appUserId && x.OperationClaimId == operationClaimId, enableTracking: false);
            if (!userOperationClaims.Items.Any()) throw new BusinessException("User operation claim should be exist when requested");
        }
    }
}

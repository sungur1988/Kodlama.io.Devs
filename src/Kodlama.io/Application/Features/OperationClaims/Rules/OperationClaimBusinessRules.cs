using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }
        public async Task OperationClaimNameCannotBeDuplicated(string name)
        {
           IPaginate<OperationClaim> claims = await _operationClaimRepository.GetListAsync(x=>x.Name==name);
            if (claims.Items.Any()) throw new BusinessException($"This operation claim name {name} already exist.");
        }
    }
}

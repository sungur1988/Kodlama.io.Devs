using Application.Features.UserOperationClaims.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim
{
    public record CreateUserOperationClaimCommand(int AppUserId,int OperationClaimId) : IRequest<CreatedUserOperationClaimDto>;
}

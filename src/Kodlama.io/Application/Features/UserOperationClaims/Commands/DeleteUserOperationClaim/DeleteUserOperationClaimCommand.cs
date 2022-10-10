using Application.Features.UserOperationClaims.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim
{
    public record DeleteUserOperationClaimCommand(int Id, int AppUserId, int OperationClaimId) : IRequest<DeletedUserOperationClaimDto>;
}

﻿using Application.Features.OperationClaims.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    public record UpdateOperationClaimCommand(int Id, string Name) : IRequest<UpdatedOperationClaimDto>, ISecuredRequest
    {
        public string[] Roles => new[] {"OperationClaim.Update"};
    }
}

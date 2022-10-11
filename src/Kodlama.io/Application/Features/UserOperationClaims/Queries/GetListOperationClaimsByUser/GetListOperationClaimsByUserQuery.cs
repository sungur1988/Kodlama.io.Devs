using Application.Features.UserOperationClaims.Models;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Queries.GetListOperationClaimsByUser
{
    public record GetListOperationClaimsByUserQuery(int Id,PageRequest PageRequest) : IRequest<GetListOperationClaimsByUserModel>;
}

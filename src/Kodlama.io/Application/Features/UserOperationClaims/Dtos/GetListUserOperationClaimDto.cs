using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Dtos
{
    public class GetListUserOperationClaimDto
    {
        public OperationClaimDto Claim { get; set; }
    }
}

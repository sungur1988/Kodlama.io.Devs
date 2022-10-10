using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [HttpPost("{userId}")]
        public async Task<IActionResult> CreateUserOperationClaim([FromRoute] int userId, [FromQuery] int operationClaimId)
        {
            CreatedUserOperationClaimDto result = await  Mediator.Send(new CreateUserOperationClaimCommand(userId, operationClaimId));
            return Created("", result);
        }
    }
}

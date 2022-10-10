using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [HttpPost()]
        public async Task<IActionResult> CreateUserOperationClaim([FromBody] CreateUserOperationClaimCommand request)
        {
            CreatedUserOperationClaimDto result = await  Mediator.Send(request);
            return Created("", result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUserOperationClaim([FromBody] DeleteUserOperationClaimCommand request)
        {
            DeletedUserOperationClaimDto result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}

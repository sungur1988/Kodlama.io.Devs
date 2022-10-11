using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Queries.GetListOperationClaimsByUser;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateUserOperationClaim([FromBody] CreateUserOperationClaimCommand request)
        {
            CreatedUserOperationClaimDto result = await Mediator.Send(request);
            return Created("", result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUserOperationClaim([FromBody] DeleteUserOperationClaimCommand request)
        {
            DeletedUserOperationClaimDto result = await Mediator.Send(request);
            return Ok(result);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> GetListOperationClaimsByUser([FromRoute] int id, [FromQuery]PageRequest pageRequest)
        {
            GetListOperationClaimsByUserModel result = await Mediator.Send(new GetListOperationClaimsByUserQuery(id, pageRequest));
            return Ok(result);
        }
    }
}

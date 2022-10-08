using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateOperationClaim([FromBody] CreateOperationClaimCommand request)
        {
            CreatedOperationClaimDto result = await Mediator.Send(request);
            return Created("", result);
        }
    }
}

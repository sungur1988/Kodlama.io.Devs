using Application.Features.Users.Commands.UpdateSocialMedia;
using Application.Features.Users.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateSocialMedia([FromRoute] int id, [FromBody] SocialMediaAddDto socialMediaAddDto)
        {
            UpdatedUserDto result = await Mediator.Send(new UpdateSocialMediaCommand(id, socialMediaAddDto));
            return Ok(result);
        }
    }
}

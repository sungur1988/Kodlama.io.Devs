using Application.Features.SocialMedias.Command.CreateSocialMedia;
using Application.Features.SocialMedias.Command.UpdateSocialMedia;
using Application.Features.SocialMedias.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia([FromBody] CreateSocialMediaCommand request)
        {
            CreatedSocialMediaDto result = await Mediator.Send(request);
            return Created("", result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia([FromBody] UpdateSocialMediaCommand request)
        {
            UpdatedSocialMediaDto result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}

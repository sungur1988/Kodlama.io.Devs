using Application.Features.SocialMedias.Command.CreateSocialMedia;
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
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand request)
        {
            CreatedSocialMediaDto result = await Mediator.Send(request);
            return Created("", result);
        }
    }
}

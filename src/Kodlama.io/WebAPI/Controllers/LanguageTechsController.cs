using Application.Features.LanguageTechs.Commands.CreateLanguageTech;
using Application.Features.LanguageTechs.Commands.DeleteLanguageTech;
using Application.Features.LanguageTechs.Commands.UpdateLanguageTech;
using Application.Features.LanguageTechs.Dtos;
using Application.Features.LanguageTechs.Queries.GetLanguageTechById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageTechsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateLanguageTech(CreateLanguageTechCommand request)
        {
            CreatedLanguageTechDto result = await Mediator.Send(request);
            return Created("",result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLanguageTech(UpdateLanguageTechCommand request)
        {
            UpdatedLanguageTechDto result = await Mediator.Send(request);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteLanguageTech(DeleteLanguageTechCommand request)
        {
            DeletedLanguageTechDto result = await Mediator.Send(request);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetLanguageTechById([FromRoute] GetLangugageTechByIdQuery request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}

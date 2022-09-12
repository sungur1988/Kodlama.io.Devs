using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateProgrammingLanguage(CreateProgrammingLanguageCommand request)
        {
            var result = await Mediator.Send(request);
            return Created("",result);
        }
    }
}

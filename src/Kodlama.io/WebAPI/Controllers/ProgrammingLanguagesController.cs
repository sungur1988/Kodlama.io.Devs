using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguageById;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateProgrammingLanguage([FromBody] CreateProgrammingLanguageCommand request)
        {
            CreatedProgrammingLanguageDto result = await Mediator.Send(request);
            return Created("", result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProgrammingLanguage([FromBody] UpdateProgrammingLanguageCommand request)
        {
            UpdatedProgrammingLanguageDto result = await Mediator.Send(request);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProgrammingLanguage([FromBody] DeleteProgrammingLanguageCommand request)
        {
            DeletedProgrammingLanguageDto result = await Mediator.Send(request);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetProgrammingLanguageById([FromRoute] GetProgrammingLanguageByIdQuery request)
        {
            GetByIdProgrammingLanguageDto result = await Mediator.Send(request);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetListProgrammingLanguage([FromQuery] PageRequest pageRequest)
        {
            ProgrammingLanguageListModel result = await Mediator.Send(new GetListProgrammingLanguageQuery(pageRequest));
            return Ok(result);
        }

    }
}

using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Models;
using Core.Security.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            RegisterResponseModel result = await Mediator.Send(new RegisterCommand(userForRegisterDto));
            return Created("", result);
        }
    }
}

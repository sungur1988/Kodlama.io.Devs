using Application.Features.Auths.Commands;
using Application.Features.Auths.Commands.Login;
using Application.Features.Auths.Commands.Register;
using Application.Features.Auths.Dtos;
using Core.Security.Dtos;
using Core.Security.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto)
        {
            string? ipAddress = GetIpAddress();
            RegisteredDto result = await Mediator.Send(new RegisterCommand(userForRegisterDto, ipAddress));
            SetRefreshTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto userForLoginDto)
        {
            string? ipAddress = GetIpAddress();
            LoggedInDto result = await Mediator.Send(new LoginCommand(userForLoginDto, ipAddress));
            SetRefreshTokenToCookie(result.RefreshToken);
            return Ok(result.AccessToken);
        }

        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
    }
}

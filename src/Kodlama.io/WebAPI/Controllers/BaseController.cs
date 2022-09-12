using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetRequiredService<IMediator>();
        private readonly IMediator _mediator;
    }
}

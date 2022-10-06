using Application.Features.Auths.Dtos;
using Core.Security.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Login
{
    public record LoginCommand(UserForLoginDto UserForLoginDto,string IpAddress):IRequest<LoggedInDto>;
}

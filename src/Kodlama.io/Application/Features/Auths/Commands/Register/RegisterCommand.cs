using Application.Features.Auths.Dtos;
using Core.Security.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Application.Features.Auths.Commands.Register
{
    public record RegisterCommand(UserForRegisterDto UserForRegisterDto, string IpAddress) : IRequest<RegisteredDto>;

}

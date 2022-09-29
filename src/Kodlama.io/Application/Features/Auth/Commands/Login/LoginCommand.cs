using Application.Features.Auth.Models;
using Core.Security.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.Login
{
    public record LoginCommand(UserForLoginDto UserForLoginDto) : IRequest<LoginResponseModel>;
}

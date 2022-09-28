using Application.Features.Auth.Models;
using Core.Security.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.Register
{
    public record RegisterCommand(UserForRegisterDto UserForRegisterDto) : IRequest<RegisterResponseModel>;
}

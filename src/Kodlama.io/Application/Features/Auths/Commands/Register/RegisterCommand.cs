using Application.Features.Auths.Dtos;
using Core.Security.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<<< HEAD:src/Kodlama.io/Application/Features/Auths/Commands/Register/RegisterCommand.cs
namespace Application.Features.Auths.Commands.Register
{
    public record RegisterCommand(UserForRegisterDto UserForRegisterDto, string ipAddress) : IRequest<RegisteredDto>;
========
namespace Application.Features.Auths.Commands
{
    public record RegisterCommand(UserForRegisterDto UserForRegisterDto,string ipAddress) : IRequest<RegisteredDto>;
>>>>>>>> a1fdfaa77bc9019fb7a9ed9c5aefaaae29c8cbac:src/Kodlama.io/Application/Features/Auths/Commands/RegisterCommand.cs
}

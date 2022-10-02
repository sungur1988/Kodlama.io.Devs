using Application.Features.Users.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.UpdateSocialMedia
{
    public record UpdateSocialMediaCommand(int Id,SocialMediaAddDto SocialMedia):IRequest<UpdatedUserDto>;
}

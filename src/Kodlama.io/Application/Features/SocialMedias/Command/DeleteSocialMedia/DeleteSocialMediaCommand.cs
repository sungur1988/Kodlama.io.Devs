using Application.Features.SocialMedias.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Command.DeleteSocialMedia
{
    public record DeleteSocialMediaCommand(int Id,string Name,string UrlAddress) : IRequest<DeletedSocialMediaDto>;
}

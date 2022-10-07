using Application.Features.SocialMedias.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Command.CreateSocialMedia
{
    public record CreateSocialMediaCommand(string Name, string UrlAddress, int AppUserId) : IRequest<CreatedSocialMediaDto>;
}

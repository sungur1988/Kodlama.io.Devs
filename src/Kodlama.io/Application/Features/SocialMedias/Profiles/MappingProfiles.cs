using Application.Features.SocialMedias.Command.CreateSocialMedia;
using Application.Features.SocialMedias.Command.DeleteSocialMedia;
using Application.Features.SocialMedias.Command.UpdateSocialMedia;
using Application.Features.SocialMedias.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SocialMedia, CreateSocialMediaCommand>().ReverseMap();
            CreateMap<SocialMedia, CreatedSocialMediaDto>().ReverseMap();

            CreateMap<SocialMedia, UpdateSocialMediaCommand>().ReverseMap();
            CreateMap<SocialMedia,UpdatedSocialMediaDto>().ReverseMap();

            CreateMap<SocialMedia, DeleteSocialMediaCommand>().ReverseMap();
            CreateMap<SocialMedia, DeletedSocialMediaDto>().ReverseMap();
        }
    }
}

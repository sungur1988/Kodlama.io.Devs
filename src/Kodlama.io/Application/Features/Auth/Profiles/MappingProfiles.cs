using Application.Features.Auth.Dtos;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AppUser, RegisteredUserDto>().ReverseMap();
            CreateMap<AppUser, UserForRegisterDto>().ReverseMap();
            CreateMap<AppUser, LoggedInDto>().ReverseMap();
        }
    }
}

using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using AutoMapper;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>()
                .ForMember(x => x.AppUserId, opt => opt.MapFrom(x => x.UserId))
                .ReverseMap();
            CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.UserId))
                .ReverseMap();
        }
    }
}

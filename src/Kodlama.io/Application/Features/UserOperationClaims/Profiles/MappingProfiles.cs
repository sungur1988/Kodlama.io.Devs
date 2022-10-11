using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
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
            CreateMap<IPaginate<UserOperationClaim>, GetListOperationClaimsByUserModel>().ReverseMap();
            CreateMap<UserOperationClaim,GetListUserOperationClaimDto>().
                ForMember(dst=>dst.Claim,opt=> opt.MapFrom(src => src.OperationClaim));
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimDto>().ReverseMap();
        }
    }
}

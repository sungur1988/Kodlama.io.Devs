using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Queries.GetListOperationClaimsByUser
{
    public class GetListOperationClaimsByUserQueryHandler : IRequestHandler<GetListOperationClaimsByUserQuery, GetListOperationClaimsByUserModel>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public GetListOperationClaimsByUserQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, IUserRepository userRepository, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<GetListOperationClaimsByUserModel> Handle(GetListOperationClaimsByUserQuery request, CancellationToken cancellationToken)
        {
            AppUser? appUser = await _userRepository.GetAsync(x => x.Id == request.Id);
            _userOperationClaimBusinessRules.UserShouldBeExistWhenRequested(appUser);

            IPaginate<UserOperationClaim>? userOperationClaims = await _userOperationClaimRepository.GetListAsync(
                                                                                                                    x => x.UserId == request.Id,
                                                                                                                    include: x => x.Include(x => x.OperationClaim),
                                                                                                                    index: request.PageRequest.Page,
                                                                                                                    size: request.PageRequest.PageSize);
            GetListOperationClaimsByUserModel model = _mapper.Map<GetListOperationClaimsByUserModel>(userOperationClaims);

            return model;
        }
    }
}

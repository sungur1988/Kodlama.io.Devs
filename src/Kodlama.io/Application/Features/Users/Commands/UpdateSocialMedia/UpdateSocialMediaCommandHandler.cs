using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.UpdateSocialMedia
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand, UpdatedUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;
        public UpdateSocialMediaCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<UpdatedUserDto> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            AppUser? entityToUpdate = await _userRepository.GetUserWithSocialMedia(request.Id);
            _userBusinessRules.UserMustBeExistedWhenUpdatedOrDeleted(entityToUpdate);

            SocialMedia socialMediaToAdd = _mapper.Map<SocialMedia>(request.SocialMedia);
            _userBusinessRules.SocialMediaAddressCannotBeDuplicatedWhenUpdated(entityToUpdate, socialMediaToAdd);
            entityToUpdate.SocialMedias.Add(socialMediaToAdd);
            AppUser updatedEntity = await _userRepository.UpdateAsync(entityToUpdate);
            UpdatedUserDto mappedEntity = _mapper.Map<UpdatedUserDto>(updatedEntity);

            return mappedEntity;
        }
    }
}

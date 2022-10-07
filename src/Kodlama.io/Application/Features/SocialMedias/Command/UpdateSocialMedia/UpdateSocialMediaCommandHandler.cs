using Application.Features.SocialMedias.Dtos;
using Application.Features.SocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Command.UpdateSocialMedia
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand, UpdatedSocialMediaDto>
    {
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly IMapper _mapper;
        private readonly SocialMediaBusinessRules _socialMediaBusinessRules;

        public UpdateSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper, SocialMediaBusinessRules socialMediaBusinessRules)
        {
            _socialMediaRepository = socialMediaRepository;
            _mapper = mapper;
            _socialMediaBusinessRules = socialMediaBusinessRules;
        }

        public async Task<UpdatedSocialMediaDto> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            await _socialMediaBusinessRules.SocialMediaAddressCannotBeDuplicatedWhenCreatedOrUpdated(request.UrlAddress);
            await _socialMediaBusinessRules.SocialMediaAddressMustBeExistWhenRequested(request.Id);

            SocialMedia entityToUpdate = _mapper.Map<SocialMedia>(request);
            SocialMedia updatedEntity = await _socialMediaRepository.UpdateAsync(entityToUpdate);
            UpdatedSocialMediaDto mappedEntity = _mapper.Map<UpdatedSocialMediaDto>(updatedEntity);

            return mappedEntity;
        }
    }
}

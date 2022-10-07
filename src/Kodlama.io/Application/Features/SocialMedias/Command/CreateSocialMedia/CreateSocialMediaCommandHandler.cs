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

namespace Application.Features.SocialMedias.Command.CreateSocialMedia
{
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand, CreatedSocialMediaDto>
    {
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly IMapper _mapper;
        private readonly SocialMediaBusinessRules _socialMediaBusinessRules;

        public CreateSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper, SocialMediaBusinessRules socialMediaBusinessRules)
        {
            _socialMediaRepository = socialMediaRepository;
            _mapper = mapper;
            _socialMediaBusinessRules = socialMediaBusinessRules;
        }

        public async Task<CreatedSocialMediaDto> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            await _socialMediaBusinessRules.SocialMediaAddressCannotBeDuplicatedWhenCreatedOrUpdated(request.UrlAddress);

            SocialMedia entityToAdd = _mapper.Map<SocialMedia>(request);
            SocialMedia addedEntity = await _socialMediaRepository.AddAsync(entityToAdd);
            CreatedSocialMediaDto mappedEntity = _mapper.Map<CreatedSocialMediaDto>(addedEntity);

            return mappedEntity;
        }
    }
}

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

namespace Application.Features.SocialMedias.Command.DeleteSocialMedia
{
    public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand, DeletedSocialMediaDto>
    {
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly IMapper _mapper;
        private readonly SocialMediaBusinessRules _socialMediaBusinessRules;

        public DeleteSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper, SocialMediaBusinessRules socialMediaBusinessRules)
        {
            _socialMediaRepository = socialMediaRepository;
            _mapper = mapper;
            _socialMediaBusinessRules = socialMediaBusinessRules;
        }

        public async Task<DeletedSocialMediaDto> Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
        {
            await _socialMediaBusinessRules.SocialMediaAddressMustBeExistWhenRequested(request.Id);

            SocialMedia entityToDelete = _mapper.Map<SocialMedia>(request);
            SocialMedia deletedEntity = await _socialMediaRepository.DeleteAsync(entityToDelete);
            DeletedSocialMediaDto mappedEntity = _mapper.Map<DeletedSocialMediaDto>(deletedEntity);

            return mappedEntity;
        }
    }
}

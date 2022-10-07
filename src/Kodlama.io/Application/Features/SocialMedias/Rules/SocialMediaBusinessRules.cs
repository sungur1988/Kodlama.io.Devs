using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Rules
{
    public class SocialMediaBusinessRules
    {
        private readonly ISocialMediaRepository _socialMediaRepository;

        public SocialMediaBusinessRules(ISocialMediaRepository socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task SocialMediaAddressCannotBeDuplicatedWhenCreatedOrUpdated(string urlAddress)
        {
            SocialMedia? socialMedia = await _socialMediaRepository.GetAsync(x => x.UrlAddress == urlAddress);
            if (socialMedia is not null) throw new BusinessException($"This urladdress {urlAddress} already exist");
        }
    }
}

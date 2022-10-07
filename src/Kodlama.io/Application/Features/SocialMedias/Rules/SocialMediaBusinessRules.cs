using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
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
        public async Task SocialMediaAddressMustBeExistWhenRequested(int id)
        {
            IPaginate<SocialMedia>? socialMedias = await _socialMediaRepository.GetListAsync(x=>x.Id==id,enableTracking:false);
            if (!socialMedias.Items.Any()) throw new BusinessException($"Social media with {id} cannot found");
        }
    }
}

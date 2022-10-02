using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        public void UserMustBeExistedWhenUpdatedOrDeleted(AppUser? appUser)
        {
            if (appUser is null) throw new BusinessException("User must be existed when requested");
        }
        public void SocialMediaAddressCannotBeDuplicatedWhenUpdated(AppUser appUser,SocialMedia socialMedia)
        {
            foreach (SocialMedia item in appUser.SocialMedias)
            {
                if (item.UrlAddress == socialMedia.UrlAddress) throw new BusinessException($"Social media with {socialMedia.UrlAddress} url already exist");
            }
        }
    }
}

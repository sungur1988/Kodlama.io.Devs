using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCannotBeDuplicatedWhenRegistered(string email)
        {
            IPaginate<User> entities = await _userRepository.GetListAsync(x=>x.Email==email,enableTracking:false);
            foreach (User item in entities.Items)
            {
                if (item.Email == email) throw new BusinessException($"Email address {email} already exist");
            }
        }
    }
}

using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCannotBeDuplicatedWhenUserRegister(string email)
        {
            User? user = await _userRepository.GetAsync(x => x.Email == email);
            if (user != null) throw new BusinessException($"Email address {email} already exist.");
        }
        public void UserCannotBeNullWhenRequested(User? user)
        {
            if (user is null) throw new BusinessException($"User cannot found");
        }
    }
}

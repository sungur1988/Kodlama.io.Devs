using Application.Features.Auth.Dtos;
using Application.Features.Auth.Models;
using Application.Features.Auth.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponseModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly ITokenHelper _tokenHelper;

        public LoginCommandHandler(IUserRepository userRepository, IMapper mapper, AuthBusinessRules authBusinessRules, ITokenHelper tokenHelper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authBusinessRules = authBusinessRules;
            _tokenHelper = tokenHelper;
        }

        public async Task<LoginResponseModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetAsync(x => x.Email == request.UserForLoginDto.Email);

            _authBusinessRules.UserMustBeExistWhenLoggedIn(user);

            bool result = HashingHelper.VerifyPasswordHash(request.UserForLoginDto.Password, user.PasswordHash, user.PasswordSalt);
            IList<OperationClaim> claims = await _userRepository.GetClaims(user);
            if (!result){
                throw new AuthorizationException("Email or password is wrong");
            }

            AccessToken token = _tokenHelper.CreateToken(user, claims);
            LoggedInDto mappedUser = _mapper.Map<LoggedInDto>(user);

            return new LoginResponseModel { LoggedInDto = mappedUser, Token = token };
        }
    }
}

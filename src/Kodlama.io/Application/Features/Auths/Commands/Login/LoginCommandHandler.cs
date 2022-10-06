using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthServices;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedInDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IAuthService _authService;
        public LoginCommandHandler(IUserRepository userRepository, AuthBusinessRules authBusinessRules, IAuthService authService)
        {
            _userRepository = userRepository;
            _authBusinessRules = authBusinessRules;
            _authService = authService;
        }

        public async Task<LoggedInDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            AppUser? user = await _userRepository.GetAsync(x=>x.Email==request.UserForLoginDto.Email);
            _authBusinessRules.UserCannotBeNullWhenRequested(user);

            bool loginResult = HashingHelper.VerifyPasswordHash(request.UserForLoginDto.Password, user.PasswordHash, user.PasswordSalt);
            if (!loginResult) throw new AuthorizationException("Email address or password is wrong");

            AccessToken accessToken = await _authService.CreateAccessToken(user);
            RefreshToken refreshToken = await _authService.CreateRefreshToken(user,request.IpAddress);
            RefreshToken addedRefreshToken = await _authService.AddRefresToken(refreshToken);

            return new LoggedInDto { AccessToken = accessToken, RefreshToken = addedRefreshToken };
        }
    }
}

using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthServices;
using Application.Services.Repositories;
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

namespace Application.Features.Auths.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
    {
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IAuthService authService, AuthBusinessRules authBusinessRules, IUserRepository userRepository)
        {
            _authService = authService;
            _authBusinessRules = authBusinessRules;
            _userRepository = userRepository;
        }

        public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.EmailCannotBeDuplicatedWhenUserRegister(request.UserForRegisterDto.Email);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);

            AppUser entityToAdd = new()
            {
                FirstName = request.UserForRegisterDto.FirstName,
                LastName = request.UserForRegisterDto.LastName,
                Email = request.UserForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            AppUser addedUser = await _userRepository.AddAsync(entityToAdd);

            AccessToken accessToken = await _authService.CreateAccessToken(addedUser);
            RefreshToken refreshToken = await _authService.CreateRefreshToken(addedUser, request.ipAddress);
            RefreshToken addedRefreshToken = await _authService.AddRefresToken(refreshToken);

            return new RegisteredDto { AccessToken = accessToken, RefreshToken = addedRefreshToken };
        }
    }
}

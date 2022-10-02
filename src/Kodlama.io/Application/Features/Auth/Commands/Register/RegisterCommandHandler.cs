using Application.Features.Auth.Dtos;
using Application.Features.Auth.Models;
using Application.Features.Auth.Rules;
using Application.Services.Repositories;
using AutoMapper;
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

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponseModel>
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly AuthBusinessRules _authBusinessRules;

        public RegisterCommandHandler(ITokenHelper tokenHelper, IUserRepository userRepository, IMapper mapper, AuthBusinessRules authBusinessRules)
        {
            _tokenHelper = tokenHelper;
            _userRepository = userRepository;
            _mapper = mapper;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<RegisterResponseModel> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.EmailCannotBeDuplicatedWhenRegistered(request.UserForRegisterDto.Email);

            AppUser entityToRegister = _mapper.Map<AppUser>(request.UserForRegisterDto);
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);
            entityToRegister.PasswordSalt = passwordSalt;
            entityToRegister.PasswordHash = passwordHash;
            entityToRegister.Status = true;

            AppUser addedEntity = await _userRepository.AddAsync(entityToRegister);
            IList<OperationClaim> claims = await _userRepository.GetClaims(addedEntity);

            AccessToken token = _tokenHelper.CreateToken(addedEntity, claims);
            RegisteredUserDto mappedEntity = _mapper.Map<RegisteredUserDto>(addedEntity);

            return new RegisterResponseModel { RegisteredUserDto = mappedEntity,Token=token };

        }
    }
}

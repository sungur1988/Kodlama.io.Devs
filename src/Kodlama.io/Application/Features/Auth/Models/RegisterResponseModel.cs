using Application.Features.Auth.Dtos;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Models
{
    public class RegisterResponseModel
    {
        public RegisteredUserDto RegisteredUserDto { get; set; }
        public AccessToken Token { get; set; }
    }
}

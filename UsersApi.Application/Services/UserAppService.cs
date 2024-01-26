using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Application.Dtos;
using UsersApi.Application.Interfaces;
using UsersApi.Domain.Interfaces.Services;
using UsersApi.Domain.Models;

namespace UsersApi.Application.Services
{
    /// <summary>
    /// Implementação dos serviços de aplicação
    /// </summary>
    public class UserAppService : IUserAppService
    {
        private readonly IUserDomainService? _userDomainService;

        public UserAppService(IUserDomainService? userDomainService)
        {
            _userDomainService = userDomainService;
        }

        public UserCreateResponseDto Create(UserCreateRequestDto request)
        {
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
            };

            var result = _userDomainService?.Create(user);

            var response = new UserCreateResponseDto
            {
                Id = result?.Id,
                Name = result?.Name,
                Email = result?.Email,
                Role = result?.Role?.Name
            };

            return response;
        }

        public UserAuthResponseDto Authenticate(UserAuthRequestDto request)
        {
            var user = _userDomainService?.Authenticate(request.Email, request.Password);

            var response = new UserAuthResponseDto
            {
                Id = user?.Id,
                Name = user?.Name,
                Email = user?.Email,
                Role = user?.Role?.Name,      
                AccessToken = user?.AccessToken
            };

            return response;
        }
    }
}

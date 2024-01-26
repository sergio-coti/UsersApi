using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Application.Dtos;

namespace UsersApi.Application.Interfaces
{
    /// <summary>
    /// Interface para as operações de serviço de aplicação
    /// </summary>
    public interface IUserAppService
    {
        /// <summary>
        /// Serviço da aplicação para criar usuário
        /// </summary>
        UserCreateResponseDto Create(UserCreateRequestDto request);

        /// <summary>
        /// Serviço da aplicação para autenticar usuário
        /// </summary>
        UserAuthResponseDto Authenticate(UserAuthRequestDto request);
    }
}

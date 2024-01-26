using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Domain.Models;

namespace UsersApi.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface de serviços de domínio para o modelo 'usuário'
    /// </summary>
    public interface IUserDomainService
    {
        User? Create(User user);
        User? Authenticate(string email, string password);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Domain.Models;

namespace UsersApi.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface específica para definição dos métodos do repositório de usuário
    /// </summary>
    public interface IUserRepository : IBaseRepository<User>
    {

    }
}

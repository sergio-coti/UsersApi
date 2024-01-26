using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Domain.Models;

namespace UsersApi.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface de serviços de domínio para o modelo 'perfil'
    /// </summary>
    public interface IRoleDomainService
    {
        List<Role> GetAll();
        Role GetById(Guid id);
    }
}

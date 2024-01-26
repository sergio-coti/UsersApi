using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Domain.Interfaces.Repositories;
using UsersApi.Domain.Interfaces.Services;
using UsersApi.Domain.Models;

namespace UsersApi.Domain.Services
{
    /// <summary>
    /// CLasse de serviço de domínio para 'perfil'
    /// </summary>
    public class RoleDomainService : IRoleDomainService
    {
        private readonly IUnitOfWork? _unitOfWork;

        public RoleDomainService(IUnitOfWork? unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Role> GetAll()
        {
            return _unitOfWork?.RoleRepository?.GetAll();
        }

        public Role GetById(Guid id)
        {
            return _unitOfWork?.RoleRepository.GetById(id);
        }
    }
}

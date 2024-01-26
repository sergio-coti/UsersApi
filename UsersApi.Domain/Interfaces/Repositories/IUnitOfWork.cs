using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApi.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRoleRepository? RoleRepository { get; }
        IUserRepository? UserRepository { get; }

        void SaveChanges();
    }
}

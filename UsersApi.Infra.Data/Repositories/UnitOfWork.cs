using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Domain.Interfaces.Repositories;
using UsersApi.Infra.Data.Contexts;

namespace UsersApi.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext? _dataContext;

        public UnitOfWork(DataContext? dataContext)
        {
            _dataContext = dataContext;
        }

        public IRoleRepository? RoleRepository => new RoleRepository(_dataContext);

        public IUserRepository? UserRepository => new UserRepository(_dataContext);

        public void SaveChanges()
        {
            _dataContext?.SaveChanges();
        }

        public void Dispose()
        {
            _dataContext?.Dispose();
        }
    }
}

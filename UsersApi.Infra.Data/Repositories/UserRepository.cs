using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Domain.Interfaces.Repositories;
using UsersApi.Domain.Models;
using UsersApi.Infra.Data.Contexts;

namespace UsersApi.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DataContext? _dataContext;

        public UserRepository(DataContext? dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public override User? Get(Func<User, bool> where)
        {
            return _dataContext?
                .Set<User>()
                .Include(u => u.Role) //LEFT JOIN
                .Where(where)
                .FirstOrDefault();
        }
    }
}

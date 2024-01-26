using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Domain.Interfaces.Repositories;
using UsersApi.Infra.Data.Contexts;

namespace UsersApi.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório base
    /// </summary>
    public abstract class BaseRepository<TModel> : IBaseRepository<TModel>
        where TModel : class
    {
        private readonly DataContext? _dataContext;

        protected BaseRepository(DataContext? dataContext)
        {
            _dataContext = dataContext;
        }

        public virtual void Add(TModel model)
        {
            _dataContext?.Add(model);
        }

        public virtual void Update(TModel model)
        {
            _dataContext?.Update(model);
        }

        public virtual void Delete(TModel model)
        {
            _dataContext?.Remove(model);
        }

        public virtual List<TModel>? GetAll()
        {
            return _dataContext?.Set<TModel>().ToList();
        }

        public virtual TModel? GetById(Guid id)
        {
            return _dataContext?.Set<TModel>().Find(id);
        }        

        public virtual List<TModel>? GetAll(Func<TModel, bool> where)
        {
            return _dataContext?.Set<TModel>().Where(where).ToList();
        }

        public virtual TModel? Get(Func<TModel, bool> where)
        {
            return _dataContext?.Set<TModel>().FirstOrDefault(where);
        }

        public virtual void Dispose()
        {
            _dataContext?.Dispose();
        }
    }
}

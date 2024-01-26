using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApi.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface genérica para definição dos métodos do repositório
    /// </summary>
    public interface IBaseRepository<TModel> : IDisposable
        where TModel : class
    {
        void Add(TModel model);
        void Update(TModel model);
        void Delete(TModel model);
        List<TModel>? GetAll();
        List<TModel>? GetAll(Func<TModel, bool> where);
        TModel? GetById(Guid id);
        TModel? Get(Func<TModel, bool> where);
    }
}

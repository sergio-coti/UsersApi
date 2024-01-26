using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Domain.Interfaces.Models;
using UsersApi.Domain.Validations;

namespace UsersApi.Domain.Models
{
    /// <summary>
    /// Modelo de entidade
    /// </summary>
    public class Role : IModel
    {
        #region Propriedades

        public Guid? Id { get; set; }
        public string? Name { get; set; }

        #endregion

        #region Relacionamentos

        public ICollection<User>? Users { get; set; }

        #endregion

        #region Validação dos dados

        public ValidationResult Validate => new RoleValidation().Validate(this);

        #endregion
    }
}

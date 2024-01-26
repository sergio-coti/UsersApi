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
    public class User : IModel
    {
        #region Propriedades

        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Guid? RoleId { get; set; }
        public string? AccessToken { get; set; }

        #endregion

        #region Relacionamentos

        public Role? Role { get; set; }

        #endregion

        #region Validação dos dados

        public ValidationResult Validate => new UserValidation().Validate(this);

        #endregion
    }
}

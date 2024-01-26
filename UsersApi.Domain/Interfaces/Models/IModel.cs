using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApi.Domain.Interfaces.Models
{
    /// <summary>
    /// Contrato para os modelos de dados do domínio
    /// </summary>
    public interface IModel
    {
        #region Identificador único

        Guid? Id { get; set; }

        #endregion

        #region Método para retornar o resultado das validações

        ValidationResult Validate { get; }

        #endregion
    }
}

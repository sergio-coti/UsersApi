using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Domain.Models;

namespace UsersApi.Domain.Validations
{
    /// <summary>
    /// Classe de mapeamento de validação para 'Role'
    /// </summary>
    public class RoleValidation : AbstractValidator<Role>
    {
        /// <summary>
        /// Método construtor para criar as regras de validação
        /// </summary>
        public RoleValidation()
        {
            RuleFor(r => r.Id)
                .NotEmpty()
                .WithMessage("O Id do perfil é obrigatório");

            RuleFor(r => r.Name)
                .NotEmpty()
                .Length(6, 20)
                .WithMessage("O Nome do perfil é obrigatório e deve ter de 6 a 20 caracteres.");
        }
    }
}

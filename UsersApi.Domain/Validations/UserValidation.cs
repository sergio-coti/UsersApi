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
    /// Classe de mapeamento de validação para 'User'
    /// </summary>
    public class UserValidation : AbstractValidator<User>
    {
        /// <summary>
        /// Método construtor para criar as regras de validação
        /// </summary>
        public UserValidation()
        {
            RuleFor(u => u.Id)
                .NotEmpty()
                .WithMessage("O Id do usuário é obrigatório.");

            RuleFor(u => u.Name)
                .NotEmpty()
                .WithMessage("O Nome do usuário é obrigatório.")
                .Length(8, 100)
                .WithMessage("O Nome do usuário deve ter de 8 a 100 caracteres.");

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("O Email do usuário é obrigatório.")
                .EmailAddress()
                .WithMessage("O Email do usuário é obrigatório de deve conter um endereço válido.");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("A Senha do usuário é obrigatório.")
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[!@#$%^&*()_+])[A-Za-z\\d!@#$%^&*()_+]{8,}$")
                .WithMessage("A Senha do usuário é obrigatório e deve ter letras maiúsculas, letras minúsculas, números, símbolos e pelo menos 8 caracteres.");

            RuleFor(u => u.RoleId)
                .NotEmpty()
                .WithMessage("O Id do perfil é obrigatório.");
        }
    }
}

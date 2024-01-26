using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Domain.Helpers;
using UsersApi.Domain.Interfaces.Repositories;
using UsersApi.Domain.Interfaces.Security;
using UsersApi.Domain.Interfaces.Services;
using UsersApi.Domain.Models;

namespace UsersApi.Domain.Services
{
    /// <summary>
    /// CLasse de serviço de domínio para 'usuario'
    /// </summary>
    public class UserDomainService : IUserDomainService
    {
        private readonly IUnitOfWork? _unitOfWork;
        private readonly IJwtBearerSecurity? _jwtBearerSecurity;

        public UserDomainService(IUnitOfWork? unitOfWork, IJwtBearerSecurity? jwtBearerSecurity)
        {
            this._unitOfWork = unitOfWork;
            _jwtBearerSecurity = jwtBearerSecurity;
        }

        public User? Create(User user)
        {
            #region Gerar o Id do usuário

            user.Id = Guid.NewGuid();

            #endregion

            #region Definir o perfil padrão do usuário

            user.RoleId = _unitOfWork?.RoleRepository?.Get(r => r.Name.Equals("USER_ROLE"))?.Id;

            #endregion

            #region Verificar se o usuário é válido

            var result = user.Validate;
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            #endregion

            #region Verificar se o email já está cadastrado

            if (_unitOfWork?.UserRepository?.Get(u => u.Email.Equals(user.Email)) != null)
                throw new ApplicationException("O email informado já está cadastrado.");

            #endregion

            #region Criptografar a senha do usuário

            user.Password = Sha1Helper.Encrypt(user.Password);

            #endregion

            #region Cadastrar o usuário

            _unitOfWork?.UserRepository?.Add(user);
            _unitOfWork?.SaveChanges();

            #endregion

            return user;
        }

        public User? Authenticate(string email, string password)
        {
            #region Consultar o usuário e verificar se ele existe

            var user = _unitOfWork?.UserRepository?.Get
                (u => u.Email.Equals(email) && u.Password.Equals(Sha1Helper.Encrypt(password)));

            if (user == null)
                throw new ApplicationException("Usuário inválido. Acesso negado.");

            #endregion

            #region Gerando o token JWT do usuário

            user.AccessToken = _jwtBearerSecurity?.GenerateToken(user.Email, user.Role?.Name);

            #endregion

            return user;
        }
    }
}

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Domain.Interfaces.Security;
using UsersApi.Infra.Security.Helpers;
using UsersApi.Infra.Security.Settings;

namespace UsersApi.Infra.Security.Services
{
    /// <summary>
    /// Classe para implementar a geração dos tokens
    /// </summary>
    public class JwtBearerSecurity : IJwtBearerSecurity
    {
        private readonly JwtBearerSettings? _jwtBearerSettings;

        public JwtBearerSecurity(IOptions<JwtBearerSettings> jwtBearerSettings)
        {
            _jwtBearerSettings = jwtBearerSettings.Value;
        }

        /// <summary>
        /// Método para gerar os TOKENS JWT
        /// </summary>
        public string GenerateToken(string userName, string role)
        {
            #region Gerar o token JWT

            var jwtSecurityToken = new JwtSecurityToken(
                claims: CreateClaims(userName, role),
                signingCredentials: CreateCredentials(),
                expires: CreateExpiration()
                );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(jwtSecurityToken);

            #endregion
        }

        /// <summary>
        /// Retornar a data e hora de expiração do token
        /// </summary>
        /// <returns></returns>
        private DateTime CreateExpiration()
        {
            return DateTime.Now.AddHours(Convert.ToDouble(_jwtBearerSettings?.ExpirationInHours));
        }

        /// <summary>
        /// Criando a chave antifalsificação do token
        /// </summary>
        private SigningCredentials CreateCredentials()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtBearerSettings?.SecurityKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            return credentials;
        }

        /// <summary>
        /// Criar as CLAIMS do usuário (permissões)
        /// </summary>
        private Claim[] CreateClaims(string userName, string role)
        {
            var claims = new Claim[]
            {   //nome do usuário autenticado             
                new Claim(ClaimTypes.Name, CryptoHelper.Encrypt(userName, _jwtBearerSettings?.SecurityKey)), 
                //perfil do usuário autenticado
                new Claim(ClaimTypes.Role, CryptoHelper.Encrypt(role, _jwtBearerSettings?.SecurityKey)) 
            };

            return claims;
        }
    }
}

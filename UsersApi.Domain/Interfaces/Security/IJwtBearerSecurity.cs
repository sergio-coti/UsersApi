using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApi.Domain.Interfaces.Security
{
    /// <summary>
    /// Interface para geração do TOKEN JWT.
    /// </summary>
    public interface IJwtBearerSecurity
    {
        /// <summary>
        /// Método para retornar o TOKEN JWT
        /// </summary>
        string GenerateToken(string userName, string role);
    }
}

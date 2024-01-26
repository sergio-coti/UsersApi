using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApi.Infra.Security.Settings
{
    /// <summary>
    /// Classe para capturar os parametros de configuração do JWT
    /// </summary>
    public class JwtBearerSettings
    {
        /// <summary>
        /// Chave antifalsificação do token
        /// </summary>
        public string? SecurityKey { get; set; }

        /// <summary>
        /// Tempo de expiração do token
        /// </summary>
        public int? ExpirationInHours { get; set; }
    }
}

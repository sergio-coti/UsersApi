using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApi.Application.Dtos
{
    /// <summary>
    /// Modelo de dados para a resposta de autenticação de usuário
    /// </summary>
    public class UserAuthResponseDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? AccessToken { get; set; }
    }
}

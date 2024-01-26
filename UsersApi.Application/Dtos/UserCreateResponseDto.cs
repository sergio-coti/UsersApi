using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApi.Application.Dtos
{
    /// <summary>
    /// Modelo de dados para a resposta de criação de usuário
    /// </summary>
    public class UserCreateResponseDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
    }
}

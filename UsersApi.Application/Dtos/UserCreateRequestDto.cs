﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApi.Application.Dtos
{
    /// <summary>
    /// Modelo de dados para a requisição de criação de usuário
    /// </summary>
    public class UserCreateRequestDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}

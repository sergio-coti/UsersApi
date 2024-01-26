using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Domain.Interfaces.Security;
using UsersApi.Infra.Security.Services;
using UsersApi.Infra.Security.Settings;

namespace UsersApi.Infra.IoC.Extensions
{
    /// <summary>
    /// Classe de extensão para configuração do JWT
    /// </summary>
    public static class JwtBearerExtension
    {
        public static IServiceCollection AddJwtBearerConfig(this IServiceCollection services, IConfiguration configuration)
        {
            //capturando as chaves do /appsettings.json contendo os parametros
            //para geração do token
            var securityKey = configuration.GetSection("JwtBearerSettings:SecurityKey").Value;
            var expirationInHours = configuration.GetSection("JwtBearerSettings:ExpirationInHours").Value;

            //configuração da politica de autenticação do projeto
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    //definindo as preferencias para autenticação com TOKEN JWT
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false, //validar o emissor do token
                        ValidateAudience = false, //validar o destinatário do token
                        ValidateLifetime = true, //validar o tempo de expiração do token
                        ValidateIssuerSigningKey = true, //validar a chave secreta utilizada pelo emissor do token
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)) //chave
                    };
                });

            services.Configure<JwtBearerSettings>(configuration.GetSection("JwtBearerSettings"));
            services.AddTransient<IJwtBearerSecurity, JwtBearerSecurity>();

            return services;
        }
    }
}

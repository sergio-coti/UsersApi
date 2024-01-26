using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Application.Interfaces;
using UsersApi.Application.Services;
using UsersApi.Domain.Interfaces.Repositories;
using UsersApi.Domain.Interfaces.Services;
using UsersApi.Domain.Services;
using UsersApi.Infra.Data.Repositories;

namespace UsersApi.Infra.IoC.Extensions
{
    /// <summary>
    /// Classe de extensão para mapear os serviços do projeto
    /// </summary>
    public static class ServicesExtension
    {
        public static IServiceCollection AddServicesConfig(this IServiceCollection services)
        {
            services.AddTransient<IUserAppService, UserAppService>();
            services.AddTransient<IUserDomainService, UserDomainService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

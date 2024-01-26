using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Domain.Models;
using UsersApi.Infra.Data.Contexts;

namespace UsersApi.Infra.IoC.Extensions
{
    /// <summary>
    /// Classe de extensão para configuração do EntityFramework
    /// </summary>
    public static class EntityFrameworkExtension
    {
        public static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
        {
            //capturando o tipo de configuração de banco de dados (InMemory ou SqlServer)
            var databaseProvider = configuration.GetSection("DatabaseProvider").Value;
            var name = "BDUsersApi";

            switch (databaseProvider)
            {
                case "InMemory":

                    //injetar uma instancia de banco de dados em memória
                    services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase(name));

                    //carga de dados no banco de memória
                    LoadInMemoryData(services);
                    break;

                case "SqlServer":

                    //capturar a string de conexão contida no /appsettings.json
                    var connectionString = configuration.GetConnectionString(name);

                    //injetar a connectionstring na classe DataContext
                    services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
                    break;
            }            

            return services;
        }

        /// <summary>
        /// Carga de dados quando a aplicação rodar com banco em memória
        /// </summary>
        private static void LoadInMemoryData(IServiceCollection services)
        {
            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    //instanciando a classe DataContext
                    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
                    //verificando se a tabela 'Role' possui algum dado / registro
                    if(!dataContext.Set<Role>().Any())
                    {
                        var userRole = new Role { Id = Guid.NewGuid(), Name = "USER_ROLE" };
                        dataContext.Add(userRole);
                        dataContext.SaveChanges();

                        var userDefault = new User
                        {
                            Id = Guid.NewGuid(),
                            Name = "Usuário Default",
                            Email = "usuariodefault@email.com",
                            Password = "@Teste123",
                            RoleId = userRole.Id
                        };

                        dataContext.Add(userDefault);
                        dataContext.SaveChanges();
                    }
                }
            }
        }
    }
}

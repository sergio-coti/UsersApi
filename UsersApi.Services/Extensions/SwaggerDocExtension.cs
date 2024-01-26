using Microsoft.OpenApi.Models;
using System.Reflection;

namespace UsersApi.Services.Extensions
{
    /// <summary>
    /// Classe de extensão para configuração do swagger
    /// </summary>
    public static class SwaggerDocExtension
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            //incluir todos os endpoints do projeto na documentação do swagger
            services.AddEndpointsApiExplorer();

            //personalizando a página de documentação
            services.AddSwaggerGen(options => 
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "UsersApi - COTI Informática",
                    Description = "API REST para controle de usuários - Treinamento C# Avançado Formação Arquiteto",
                    Version = "1.0",
                    Contact = new OpenApiContact
                    {
                        Name = "COTI Informática",
                        Email = "contato@cotiinformatica.com.br",
                        Url = new Uri("http://www.cotiinformatica.com.br")
                    }
                });

                //incluindo os comentários XML do código na documentação do swagger
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options => 
            {
                options.SwaggerEndpoint("/Swagger/v1/swagger.json", "UsersApi");
            });

            return app;
        }
    }
}

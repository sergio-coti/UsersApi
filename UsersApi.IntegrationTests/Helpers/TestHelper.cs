using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApi.IntegrationTests.Helpers
{
    /// <summary>
    /// Classe auxiliar para realizar as chamadas de teste
    /// </summary>
    public static class TestHelper
    {
        /// <summary>
        /// Criando um CLIENT HTTP para acessar os métodos da API
        /// </summary>
        public static HttpClient CreateClient
            => new WebApplicationFactory<Program>().CreateClient();

        /// <summary>
        /// Serializar os dados que serão enviados nas requisições da API
        /// </summary>
        public static StringContent CreateContent<TRequest>(TRequest request)
            => new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");

        /// <summary>
        /// Deserializar a resposta obtida da API
        /// </summary>
        public static TResponse? ReadResponse<TResponse>(HttpResponseMessage message)
            => JsonConvert.DeserializeObject<TResponse>
                    (message.Content.ReadAsStringAsync().Result);
    }
}

namespace UsersApi.Services.Models
{
    /// <summary>
    /// Modelo de dados para retorno de erros da API
    /// </summary>
    public class ErrorResponseModel
    {
        /// <summary>
        /// Status HTTP do erro (4xx, 5xx etc.)
        /// </summary>
        public int? StatusCode { get; set; }

        /// <summary>
        /// Lista com as mensagens de erro
        /// </summary>
        public List<string>? Errors { get; set; }
    }
}

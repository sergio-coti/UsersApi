using FluentValidation;
using Newtonsoft.Json;
using System.Net;
using UsersApi.Services.Models;

namespace UsersApi.Services.Middlewares
{
    /// <summary>
    /// Middleware para tratamento de exceções do projeto
    /// </summary>
    public class ExceptionMiddleware
    {
        /// <summary>
        /// Capturar informações sobre a requisição HTTP realizada na API
        /// </summary>
        private readonly RequestDelegate? _requestDelegate;

        public ExceptionMiddleware(RequestDelegate? requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        /// <summary>
        /// Método para capturar as requisições e respostas da API
        /// </summary>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                //executando a requisição
                await _requestDelegate(httpContext);
            }
            catch(ValidationException e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
            catch(ApplicationException e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
            catch(Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        /// <summary>
        /// Método para realizar o tratamento das exceções no Middleware
        /// </summary>
        public async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var errorResponseModel = new ErrorResponseModel();
            errorResponseModel.Errors = new List<string>();

            switch(exception)
            {
                case ValidationException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    foreach (var item in ((ValidationException) exception).Errors)
                    {
                        errorResponseModel.Errors.Add(item.ErrorMessage);
                    }
                    break;

                case ApplicationException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResponseModel.Errors.Add(exception.Message);
                    break;

                default:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponseModel.Errors.Add("Ocorreu um erro interno, entre em contato com o nosso suporte.");
                    break;
            }

            errorResponseModel.StatusCode = httpContext.Response.StatusCode;
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(errorResponseModel));
        }
    }
}

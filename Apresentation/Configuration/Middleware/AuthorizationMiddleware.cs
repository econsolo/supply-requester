using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SupplyRequester.Apresentation.Controllers;
using SupplyRequester.Business.Services.Interfaces;
using SupplyRequester.Model.DataTransferObjects;
using SupplyRequester.Util.Exceptions;
using System;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace SupplyRequester.Apresentation.Configuration.Middleware
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAuthenticationService _authenticationService;

        public AuthorizationMiddleware(
            RequestDelegate next,
            IAuthenticationService authenticationService
        )
        {
            _next = next;
            _authenticationService = authenticationService;
        }

        public Task InvokeAsync(HttpContext context)
        {
            try
            {
                if (!context.Request.Path.Value.Contains("auth", StringComparison.InvariantCultureIgnoreCase) &&
                    !context.Request.Path.Value.Contains("swagger", StringComparison.InvariantCultureIgnoreCase))
                {
                    context.Request.Headers.TryGetValue("Authorization", out var token);

                    if (string.IsNullOrEmpty(token))
                        throw new SupplyRequesterException("É necessário se autenticar.", HttpStatusCode.Unauthorized);

                    var isTokenValid = _authenticationService.Validate(token).GetAwaiter().GetResult();

                    if (!isTokenValid)
                        throw new SupplyRequesterException("Você não está autorizado.", HttpStatusCode.Unauthorized);
                }

                var response = _next.Invoke(context);

                if (response.Exception != null)
                {
                    return HandleExceptionAsync(context, response.Exception);
                }

                return response;
            }
            catch (Exception ex)
            {
                return HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = (int)HttpStatusCode.InternalServerError;
            string messageError;

            if (exception is SupplyRequesterException srException)
            {
                code = (int)srException.HttpStatusCode;
                messageError = srException.Message;
            }
            else
            {
                messageError = "Oops! Ocorreu um erro interno no servidor :(";
            }

            var result = JsonConvert.SerializeObject(new ApiResponseDto(messageError));
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;

            return context.Response.WriteAsync(result);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PS.Domain.Entities;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PaymentSystem.Middleware
{
    public class ErrorHandlerMiddleware
    {
        public RequestDelegate requestDelegate;
        public ErrorHandlerMiddleware(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext context, ILogger<ErrorHandlerMiddleware> logger)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex, logger);
            }
        }
        private static Task HandleException(HttpContext context, Exception ex, ILogger<ErrorHandlerMiddleware> logger)
        {
            logger.LogError(ex.ToString());
            var errorMessageObject = new Error { Message = ex.Message, Code = "GE" };
            var statusCode = (int)HttpStatusCode.InternalServerError;
            switch (ex)
            {
                case InvalidAccountException e:
                    errorMessageObject.Code = "M001";
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    break;

                case ArgumentNullException e:
                    errorMessageObject.Code = "M002";
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;

            }

            var errorMessage = JsonConvert.SerializeObject(errorMessageObject);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(errorMessage);
        }
    }
}
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using WordCounter.Application.Validation;
using WordCounter.Domain.Common.Exceptions;

namespace WordCounter.Web.Middlewares.ExceptionHandler
{
    // A simple exception catcher
    // Upon catching an exception, returns the exception's message
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exc)
            {
                var errResponse = ParseException(exc);

                context.Response.StatusCode = (int)errResponse.HttpCode;

                await context.Response.WriteAsync(JsonConvert.SerializeObject(errResponse));
            }
        }

        public ErrorResponse ParseException(Exception exception)
        {
            Exception innermostException = null;

            if (exception is not null)
            {
                innermostException = GetInnermostException(exception);
            }

            var message = innermostException?.Message ?? "Unknown error.";
            // We could use the stack trace for logging
            //var stackTrace = innermostException?.StackTrace;

            // Default Http Code 
            var httpCode = HttpStatusCode.InternalServerError;

            if (innermostException is ValidationException)
            {
                httpCode = HttpStatusCode.UnprocessableEntity;
            }
            else if (innermostException is DomainException)
            {
                httpCode = HttpStatusCode.InternalServerError;
            }

            return new ErrorResponse(message, httpCode);
        }

        public Exception GetInnermostException(Exception exception)
        {
            if (exception.InnerException == null)
            {
                return exception;
            }
            else
            {
                return GetInnermostException(exception.InnerException);
            }
        }
    }
}
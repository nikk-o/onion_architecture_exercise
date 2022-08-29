using System.Net;
using System.Text.Json.Serialization;

namespace WordCounter.Web.Middlewares.ExceptionHandler
{
    public class ErrorResponse
    {
        public ErrorResponse(string message, HttpStatusCode httpCode)
        {
            Message = message;
            HttpCode = httpCode;
            //StackTrace = stackTrace;
        }

        [JsonIgnore]
        public HttpStatusCode HttpCode { get; }

        public string Message { get; }

        //public string StackTrace { get; }

    }
}

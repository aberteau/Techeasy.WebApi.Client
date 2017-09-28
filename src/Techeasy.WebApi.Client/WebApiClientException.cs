using System;
using System.Net;

namespace Techeasy.WebApi.Client
{
    public class WebApiClientException
        : Exception
    {
        private readonly HttpStatusCode _httpStatusCode;

        public WebApiClientException(HttpStatusCode httpStatusCode, String message)
            : base($"HTTP Error {httpStatusCode} : {message}")
        {
            _httpStatusCode = httpStatusCode;
        }

        public WebApiClientException(HttpStatusCode httpStatusCode, Exception exception)
            : base($"HTTP Error {httpStatusCode}", exception)
        {
            _httpStatusCode = httpStatusCode;
        }

        public HttpStatusCode StatusCode => _httpStatusCode;
    }
}

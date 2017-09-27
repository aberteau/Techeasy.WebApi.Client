using System.Net.Http;

namespace Techeasy.WebApi.Client
{
    public class WebApiResponseMessage<T>
        : IWebApiResponseMessage<T>
    {
        public WebApiResponseMessage(HttpResponseMessage httpResponseMessage, T content)
        {
            HttpResponseMessage = httpResponseMessage;
            Data = content;
        }

        public HttpResponseMessage HttpResponseMessage { get; }

        public T Data { get; }
    }
}

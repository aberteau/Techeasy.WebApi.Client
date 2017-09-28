using System.Net.Http;

namespace Techeasy.WebApi.Client
{
    public interface IWebApiResponseMessage
    {
        HttpResponseMessage HttpResponseMessage { get; }
    }

    public interface IWebApiResponseMessage<T>
         : IWebApiResponseMessage
    {
        T Data { get; }
    }
}
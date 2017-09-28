using System.Net.Http;
using System.Threading.Tasks;

namespace Techeasy.WebApi.Client
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<T> ReadContentAsAsync<T>(this HttpResponseMessage response)
            where T : class
        {
            T obj = await response.Content.ReadAsAsync<T>();
            return obj;
        }
    }
}

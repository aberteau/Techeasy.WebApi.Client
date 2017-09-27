using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Techeasy.WebApi.Client
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> GetAsync(this HttpClient httpClient, string requestUri, NameValueCollection nameValueCollection)
        {
            String uri = UriUtility.AppendQuery(requestUri, nameValueCollection);
            HttpResponseMessage obj = await httpClient.GetAsync(uri);
            return obj;
        }

        public static async Task<HttpResponseMessage> PostAsync(this HttpClient httpClient, String requestUri, HttpContent httpContent)
        {
            HttpResponseMessage response = await httpClient.PostAsync(requestUri, httpContent);
            return response;
        }

        public static async Task<HttpResponseMessage> PostAsync(this HttpClient httpClient, String requestUri, NameValueCollection nameValueCollection, HttpContent httpContent)
        {
            String uri = UriUtility.AppendQuery(requestUri, nameValueCollection);
            HttpResponseMessage response = await httpClient.PostAsync(uri, httpContent);
            return response;
        }
    }
}

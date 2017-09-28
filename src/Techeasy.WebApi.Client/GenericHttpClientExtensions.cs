using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Techeasy.WebApi.Client
{
    public static class GenericHttpClientExtensions
    {
        public static async Task<IWebApiResponseMessage<T>> GetAsync<T>(this HttpClient httpClient, string requestUri)
            where T : class
        {
            HttpResponseMessage response = await httpClient.GetAsync(requestUri);
            T obj = await response.ReadContentAsAsync<T>();
            IWebApiResponseMessage<T> webApiResponse = new WebApiResponseMessage<T>(response, obj);
            return webApiResponse;
        }

        public static async Task<IWebApiResponseMessage<T>> GetAsync<T>(this HttpClient httpClient, string requestUri, NameValueCollection nameValueCollection)
            where T : class
        {
            HttpResponseMessage response = await httpClient.GetAsync(requestUri, nameValueCollection);
            T obj = await response.ReadContentAsAsync<T>();
            IWebApiResponseMessage<T> webApiResponse = new WebApiResponseMessage<T>(response, obj);
            return webApiResponse;
        }

        public static async Task<IWebApiResponseMessage<IEnumerable<T>>> GetEnumerableAsync<T>(this HttpClient httpClient, string requestUri)
            where T : class
        {
            HttpResponseMessage response = await httpClient.GetAsync(requestUri);
            IEnumerable<T> enumerable = await response.ReadContentAsAsync<IEnumerable<T>>();
            IWebApiResponseMessage<IEnumerable<T>> webApiResponse = new WebApiResponseMessage<IEnumerable<T>>(response, enumerable);
            return webApiResponse;
        }

        public static async Task<IWebApiResponseMessage<IEnumerable<T>>> GetEnumerableAsync<T>(this HttpClient httpClient, string requestUri, NameValueCollection nameValueCollection)
            where T : class
        {
            HttpResponseMessage response = await httpClient.GetAsync(requestUri, nameValueCollection);
            IEnumerable<T> enumerable = await response.ReadContentAsAsync<IEnumerable<T>>();
            IWebApiResponseMessage<IEnumerable<T>> webApiResponse = new WebApiResponseMessage<IEnumerable<T>>(response, enumerable);
            return webApiResponse;
        }

        public static async Task<IWebApiResponseMessage<TReturn>> PostAsync<T, TReturn>(this HttpClient httpClient, String requestUri, T contentObj)
            where TReturn : class
        {
            HttpContent content = HttpContentHelper.GetHttpContent(contentObj);
            HttpResponseMessage response = await httpClient.PostAsync(requestUri, content);
            TReturn obj = await response.ReadContentAsAsync<TReturn>();
            IWebApiResponseMessage<TReturn> webApiResponse = new WebApiResponseMessage<TReturn>(response, obj);
            return webApiResponse;
        }

        public static async Task<IWebApiResponseMessage<TReturn>> PostAsync<T, TReturn>(this HttpClient httpClient, String requestUri, NameValueCollection nameValueCollection, T contentObj)
            where TReturn : class
        {
            HttpContent content = HttpContentHelper.GetHttpContent(contentObj);
            HttpResponseMessage response = await PostAsync(httpClient, requestUri, nameValueCollection, content);
            TReturn obj = await response.ReadContentAsAsync<TReturn>();
            IWebApiResponseMessage<TReturn> webApiResponse = new WebApiResponseMessage<TReturn>(response, obj);
            return webApiResponse;
        }

        public static async Task<HttpResponseMessage> PostAsync<T>(this HttpClient httpClient, String requestUri, T contentObj)
        {
            HttpContent content = HttpContentHelper.GetHttpContent(contentObj);
            HttpResponseMessage response = await httpClient.PostAsync(requestUri, content);
            return response;
        }

        public static async Task<HttpResponseMessage> PostAsync<T>(this HttpClient httpClient, String requestUri, NameValueCollection nameValueCollection, T contentObj)
        {
            HttpContent content = HttpContentHelper.GetHttpContent(contentObj);
            HttpResponseMessage response = await PostAsync(httpClient, requestUri, nameValueCollection, content);
            return response;
        }
    }
}

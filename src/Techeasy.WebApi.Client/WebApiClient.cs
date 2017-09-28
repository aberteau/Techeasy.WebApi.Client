using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Techeasy.WebApi.Client
{
    public class WebApiClient
    {
        private readonly HttpClient _httpClient;

        public WebApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #region static

        private static async Task EnsureSuccessStatusCode(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return;

            string content = await response.Content.ReadAsStringAsync();
            throw new WebApiClientException(response.StatusCode, content);
        }

        private static async Task EnsureSuccessStatusCode(IWebApiResponseMessage response)
        {
            await EnsureSuccessStatusCode(response.HttpResponseMessage);
        }

        #endregion

        public async Task<T> GetAsync<T>(string requestUri)
            where T : class
        {
            IWebApiResponseMessage<T> response = await _httpClient.GetAsync<T>(requestUri);
            await EnsureSuccessStatusCode(response);
            return response.Data;
        }

        public async Task<T> GetAsync<T>(string requestUri, NameValueCollection nameValueCollection)
            where T : class
        {
            String uri = UriUtility.AppendQuery(requestUri, nameValueCollection);
            T obj = await GetAsync<T>(uri);
            return obj;
        }

        public async Task<IEnumerable<T>> GetEnumerableAsync<T>(string requestUri)
            where T : class
        {
            IEnumerable<T> enumerable = await GetAsync<IEnumerable<T>>(requestUri);
            return enumerable;
        }

        public async Task<IEnumerable<T>> GetEnumerableAsync<T>(string requestUri, NameValueCollection nameValueCollection)
            where T : class
        {
            String uri = UriUtility.AppendQuery(requestUri, nameValueCollection);
            IEnumerable<T> enumerable = await GetEnumerableAsync<T>(uri);
            return enumerable;
        }

        public async Task PostAsync(String requestUri, HttpContent httpContent)
        {
            HttpResponseMessage response = await _httpClient.PostAsync(requestUri, httpContent);
            await EnsureSuccessStatusCode(response);
        }

        public async Task PostAsync(String requestUri, NameValueCollection nameValueCollection, HttpContent httpContent)
        {
            String uri = UriUtility.AppendQuery(requestUri, nameValueCollection);
            await PostAsync(uri, httpContent);
        }

        public async Task<TReturn> PostAsync<T, TReturn>(String requestUri, T contentObj)
            where TReturn : class
        {
            IWebApiResponseMessage<TReturn> response = await _httpClient.PostAsync<T, TReturn>(requestUri, contentObj);
            await EnsureSuccessStatusCode(response);
            TReturn obj = response.Data;
            return obj;
        }

        public async Task<TReturn> PostAsync<T, TReturn>(String requestUri, NameValueCollection nameValueCollection, T contentObj)
            where TReturn : class
        {
            String uri = UriUtility.AppendQuery(requestUri, nameValueCollection);
            TReturn obj = await PostAsync<T, TReturn>(uri, contentObj);
            return obj;
        }

        public async Task PostAsync<T>(String requestUri, T contentObj)
        {
            HttpResponseMessage response = await _httpClient.PostAsync(requestUri, contentObj);
            await EnsureSuccessStatusCode(response);
        }

        public async Task PostAsync<T>(String requestUri, NameValueCollection nameValueCollection, T contentObj)
        {
            String uri = UriUtility.AppendQuery(requestUri, nameValueCollection);
            await PostAsync(uri, contentObj);
        }
    }
}

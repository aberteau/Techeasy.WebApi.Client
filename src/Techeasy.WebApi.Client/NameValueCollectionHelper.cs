using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Techeasy.WebApi.Client
{
    public class NameValueCollectionHelper
    {
        private static string ToParameterString(string key, string value)
        {
            string encodedKey = WebUtility.UrlEncode(key);
            string encodedValue = WebUtility.UrlEncode(value);
            string parameterString = $"{encodedKey}={encodedValue}";
            return parameterString;
        }

        public static string ToParameterString(KeyValuePair<String, String> parameter)
        {
            string parameterString = ToParameterString(parameter.Key, parameter.Value);
            return parameterString;
        }

        public static string ToQueryString(String[] queryParameters)
        {
            if (!queryParameters.Any())
                return null;

            string parameterString = string.Join("&", queryParameters);
            return parameterString;
        }

        public static NameValueCollection BuildFromArray(String name, IEnumerable<String> items)
        {
            NameValueCollection nameValueCollection = new NameValueCollection();
            foreach (String item in items)
                nameValueCollection.Add(name, item);

            return nameValueCollection;
        }
    }
}

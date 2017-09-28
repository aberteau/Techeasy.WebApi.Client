using System;
using System.Linq;

namespace Techeasy.WebApi.Client
{
    public static class NameValueCollectionExtensions
    {
        private static String[] ToParameterStringArray(this NameValueCollection nameValueCollection)
        {
            String[] parameterStringArray = nameValueCollection.Select(nvp => NameValueCollectionHelper.ToParameterString(nvp)).ToArray();
            return parameterStringArray;
        }

        public static string ToQueryString(this NameValueCollection nameValueCollection)
        {
            if (nameValueCollection.IsEmpty)
                return null;

            String[] parametersString = ToParameterStringArray(nameValueCollection);
            string queryString = NameValueCollectionHelper.ToQueryString(parametersString);
            return queryString;
        }
    }
}

using System;

namespace Techeasy.WebApi.Client
{
    public static class UriUtility
    {
        public static String AppendQuery(String uri, NameValueCollection nameValueCollection)
        {
            if (String.IsNullOrWhiteSpace(uri))
                return null;

            if ((nameValueCollection == null) || (nameValueCollection.IsEmpty))
                return uri;

            String query = nameValueCollection.ToQueryString();
            string resultUri = $"{uri}?{query}";
            return resultUri;
        }
    }
}

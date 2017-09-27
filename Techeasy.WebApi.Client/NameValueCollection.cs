using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Techeasy.WebApi.Client
{
    public class NameValueCollection
        : IEnumerable<KeyValuePair<String, String>>
    {
        private readonly IList<KeyValuePair<String, String>> _nameValuePairs = new List<KeyValuePair<string, string>>();

        public void Add(String name, String value)
        {
            if(String.IsNullOrWhiteSpace(name))
                throw new Exception("name can not be null or empty");

            if (String.IsNullOrWhiteSpace(value))
                throw new Exception("value can not be null or empty");

            KeyValuePair<string, string> nameValuePair = new KeyValuePair<string, string>(name, value);
            _nameValuePairs.Add(nameValuePair);
        }

        public bool IsEmpty => !_nameValuePairs.Any();

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _nameValuePairs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _nameValuePairs.GetEnumerator();
        }
    }
}

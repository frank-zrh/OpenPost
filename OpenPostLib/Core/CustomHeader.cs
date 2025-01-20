using System.Collections.Generic;

namespace OpenPostLib.Core
{
    public class CustomHeader
    {
        public Dictionary<string, IEnumerable<string>> Headers { get; } = new Dictionary<string, IEnumerable<string>>();

        public void Add(string key, IEnumerable<string> values)
        {
            Headers[key] = values;
        }

        public IEnumerable<string>? GetValues(string key)
        {
            return Headers.TryGetValue(key, out var values) ? values : null;
        }
    }
}

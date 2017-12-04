using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Extensions
{
    public static class DictionaryExtensions
    {
        public static TValue Get<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
        {
            TValue val;
            if (dict.TryGetValue(key, out val))
            {
                return val;
            }

            return default(TValue);
        }
    }
}

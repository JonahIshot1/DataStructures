using System;
using System.Collections.Generic;
using System.Text;

namespace LRU_Cache
{
    public class ICachee<TKey, TValue> : ICache<TKey, TValue>
    {
        public LinkedList<TKey> valuesList = new();
        public Dictionary<TKey, TValue> dic = new();

        public void Put(TKey key, TValue value)
        {
            valuesList.AddFirst(key);
            dic.Add(key, value);
        }
        public void removeLast()
        {
            dic.Remove(valuesList.Last.Value);
            valuesList.RemoveLast();
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            return dic.TryGetValue(key, out value);
        }
    }
}

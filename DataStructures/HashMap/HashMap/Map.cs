using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace HashMap
{
    class Map<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly IEqualityComparer<TKey> keyComparer;
        private readonly LinkedList<KeyValuePair<TKey, TValue>>[] buckets;

        public ICollection<TKey> Keys
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return true;
            }
        }

        public TValue this[TKey key]
        {
            get 
            { 
                throw new NotImplementedException(); 
            }
            set 
            { 
                throw new NotImplementedException(); 
            }
        }               

        public Map(IEqualityComparer<TKey> comparer, ICollection<TValue> vals  )
        {
            keyComparer = comparer;
            buckets = new LinkedList<KeyValuePair<TKey, TValue>>[1000];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }

            /* rest of the constructor goes here */
        }

        public Map()
            : this(EqualityComparer<TKey>.Default, [])
        {
            /* rest of the constructor goes here */
        }

        public void Add(TKey key, TValue value)
        {
            int code = key.GetHashCode();
            code.Equals(Math.Abs(code));
            code.Equals(code % buckets.Length);
            LinkedListNode < KeyValuePair < TKey, TValue >> cur = buckets[code].First;
            for (int i = 0; i < buckets[code].Count; i++)
            {
                if (cur.Value.Key.Equals(key)) throw new Exception();
                cur=cur.Next;
            }

            KeyValuePair<TKey,TValue> val = new KeyValuePair <TKey,TValue>(key,value);
            buckets[code].AddLast(val); 
        }
        public bool ContainsKey(TKey key)
        {
            int code = key.GetHashCode();
            code.Equals(Math.Abs(code));
            code.Equals(code % buckets.Length);
            LinkedListNode<KeyValuePair<TKey, TValue>> cur = buckets[code].First;
            for (int i = 0; i < buckets[code].Count; i++)
            {
                if (cur.Value.Key.Equals(key)) return true;
                cur = cur.Next;
            }
            return false;
        }

        public bool Remove(TKey key)
        {
            int code = key.GetHashCode();
            code.Equals(Math.Abs(code));
            code.Equals(code % buckets.Length);
            LinkedListNode<KeyValuePair<TKey, TValue>> cur = buckets[code].First;
            for (int i = 0; i < buckets[code].Count; i++)
            {
                if (cur.Value.Key.Equals(key))
                {
                    buckets[code].Remove(cur);
                    return true;
                }
                cur = cur.Next;
            }
            return false; 
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            int code = key.GetHashCode();
            code.Equals(Math.Abs(code));
            code.Equals(code % buckets.Length);
            LinkedListNode<KeyValuePair<TKey, TValue>> cur = buckets[code].First;
            for (int i = 0; i < buckets[code].Count; i++)
            {
                if (cur.Value.Key.Equals(key))
                {
                    value = cur.Value.Value;
                    return true;
                }
                cur = cur.Next;
            }
            value = default;
            return false;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            int code = item.Key.GetHashCode();
            code.Equals(Math.Abs(code));
            code.Equals(code % buckets.Length);
            LinkedListNode<KeyValuePair<TKey, TValue>> cur = buckets[code].First;
            for (int i = 0; i < buckets[code].Count; i++)
            {
                if (cur.Value.Key.Equals(item.Key)) throw new Exception();
                cur = cur.Next;
            }

            KeyValuePair<TKey, TValue> val = new KeyValuePair<TKey, TValue>(item.Key, item.Value);
            buckets[code].AddLast(val);
        }

        public void Clear()
        {
            for(int i =0; i < buckets.Length;i++)
            {
                buckets[i].Clear();
            }
           
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            int code = item.Key.GetHashCode();
            code.Equals(Math.Abs(code));
            code.Equals(code % buckets.Length);
            LinkedListNode<KeyValuePair<TKey, TValue>> cur = buckets[code].First;
            for (int i = 0; i < buckets[code].Count; i++)
            {
                if (cur.Value.Key.Equals(item.Key)) return true;
                cur = cur.Next;
            }
            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /* implementations for all IDictionary methods go here */
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace HashMap
{
    public class Map<TKey, TValue> : IDictionary<TKey, TValue>
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

        public Map(IEqualityComparer<TKey> comparer, ICollection<TValue> vals)
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
            LinkedListNode<KeyValuePair<TKey, TValue>> cur = buckets[code].First;
            for (int i = 0; i < buckets[code].Count; i++)
            {
                if (cur.Value.Key.Equals(key)) throw new Exception();
                cur = cur.Next;
            }

            KeyValuePair<TKey, TValue> val = new KeyValuePair<TKey, TValue>(key, value);
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
            for (int i = 0; i < buckets.Length; i++)
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
            LinkedListNode<KeyValuePair<TKey, TValue>> cur = buckets[arrayIndex].First;
            LinkedList<KeyValuePair<TKey, TValue>> buck = new LinkedList<KeyValuePair<TKey, TValue>>();
            for (int i = 0; i < buckets[arrayIndex].Count; i++)
            {
                array[i] = cur.Value;
                cur = cur.Next;
            }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            int code = item.Key.GetHashCode();
            code.Equals(Math.Abs(code));
            code.Equals(code % buckets.Length);
            LinkedListNode<KeyValuePair<TKey, TValue>> cur = buckets[code].First;
            for (int i = 0; i < buckets[code].Count; i++)
            {
                if (cur.Value.Key.Equals(item.Key))
                {
                    buckets[code].Remove(cur);
                    return true;
                }
                cur = cur.Next;
            }
            return false;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int l = 0; l < buckets.Length; l++)
            {
                LinkedListNode<KeyValuePair<TKey, TValue>> cur = buckets[l].First;
                for (int i = 0; i < buckets[l].Count; i++)
                {
                    yield return cur.Value;
                    cur = cur.Next;
                }
            }

            //yield return curr.Value; // produce one item
            //curr = curr.Next;  // move onto the next

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /* implementations for all IDictionary methods go here */
    }
}

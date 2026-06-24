using System;
using System.Collections.Generic;
using System.Text;

namespace unionFind
{
    public class QuickUnion<T>: IUnionFind<T>
    {
        Dictionary<T, int> dict;
        int[] friends;
        public QuickUnion(T[] itemss)
        {
            dict = new Dictionary<T, int>();
            friends = new int[itemss.Length];
            for (int i = 0; i < itemss.Length; i++)
            {
                dict.Add(itemss[i], i);
                friends[i] = i;
            }
        }
        public bool AreConnected(T p, T q)
        {
            if (p == null || q == null)
            {
                throw new Exception();
            }
            if (!dict.ContainsKey(p))
            {
                throw new Exception();
            }
            if (!dict.ContainsKey(q))
            {
                throw new Exception();
            }

            int i1 = Find(p);
            int i2 = Find(q);
            return i1 == i2;
        }

        public int Find(T p)
        {
            if (p == null)
            {
                throw new Exception();
            }
            if (!dict.ContainsKey(p))
            {
                throw new Exception();
            }
            int cur = dict[p];
            while (friends[cur]!=cur)
            {
                cur= friends[cur];
            }
            return cur;
        }

        public bool Union(T p, T q)
        {
            if (p == null || q == null)
            {
                throw new Exception();
            }
            if (!dict.ContainsKey(p))
            {
                throw new Exception();
            }
            if (!dict.ContainsKey(q))
            {
                throw new Exception();
            }
            friends[dict[p]] = dict[q];
            return true;
        }

    }
}

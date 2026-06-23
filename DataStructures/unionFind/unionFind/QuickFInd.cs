using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace unionFind 
{
    public class QuickFInd<T> : IUnionFind<T>
    {
        Dictionary<T, int> dict;
        int[] friends;
        public QuickFInd(T[] itemss) 
        {
            friends = new int[itemss.Length];
            for(int i =0; i<itemss.Length;i++)
            {
                dict.Add(itemss[i], i);
                friends[i] = i;
            }
        }
        public bool AreConnected(T p, T q)
        {
            if(p==null||q==null)
            {
                throw new Exception();
            }
            int i1 = friends[dict[p]];
            int i2 = friends[dict[q]];
            return i1 == i2;
        }

        public int Find(T p)
        {
            return friends[dict[p]]; 
        }

        public bool Union(T p, T q)
        {
            int i1 = friends[dict[p]];
            int i2 = friends[dict[q]];

            for (int i = 0; i < friends.Length; i++)
            {
                if (friends[i]==i2)
                {
                    friends[i] = i1;
                }
            }
            return true;
        }
    }
}

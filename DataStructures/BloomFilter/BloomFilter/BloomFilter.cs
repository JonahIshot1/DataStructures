using System;
using System.Collections.Generic;
using System.Text;

namespace BloomFilter
{
    public class BloomFilter<T>
    {
        public bool[] used;
        public List<Func<T,int>> filters;
        public BloomFilter(int cap)
        {
            used = new bool[cap];
            filters = new List<Func<T,int>>();
            filters.Add(HashFuncOne);
            filters.Add(HashFuncTwo);
            filters.Add(HashFuncThree);
        }



        public void LoadHashFunc(Func<T, int> hashFunc)
        {
            filters.Add(hashFunc);
        }

        public void Insert(T item)
        {
            for (int i = 0; i < filters.Count; i++)
            {
                int num = Math.Abs(filters[i](item) % used.Length);
                used[num] = true;
            }
        }

        public bool ProbablyContains(T item)
        {
            bool done = true;
            for (int i = 0; i < filters.Count; i++)
            {
                int num = Math.Abs(filters[i](item) % used.Length);
                if ( !used[num])
                {
                    done = false;   
                }
            }
            return done;
        }

        private int HashFuncOne(T item)
        {
            return item.GetHashCode();
        }

        private int HashFuncTwo(T item)
        {
            string dummyString = "dummystring";
            return (dummyString, item).GetHashCode();
        }

        private int HashFuncThree(T item)
        {
            int hash = 17;

            hash *= (HashFuncOne(item), HashFuncTwo(item)).GetHashCode();

            return hash;
        }
    }
}

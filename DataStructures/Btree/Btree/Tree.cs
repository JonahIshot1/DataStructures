using System;
using System.Collections.Generic;
using System.Text;

namespace Btree
{
    public class Tree<T>
    {
        IComparer<T> comparer;
        public Node<T> root;
        public Tree (IComparer<T> comp)
        {
            comparer = comp;
        }
        public void Insert(T val)
        {
            if(root is null)
            {
                root = new Node<T>(comparer);
                root.vals.Add(val);
            }
            bool nothin = false;
            root= root.Insert(val,out nothin);

        }
        public bool Contains(T val)
        {
            if (val is null) return false;
            return root.Contains(val);
        }
    }
}

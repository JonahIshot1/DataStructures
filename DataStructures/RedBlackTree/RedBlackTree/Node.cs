using System;
using System.Collections.Generic;
using System.Text;

namespace RedBlackTree
{
    public class Node<T>
    {
        public Node(T v )
        {
            Value = v;
            IsRed = true;
        }

        public Node( )
        {
        }

        public Node<T> Left { get; set; }
        public bool IsRed;

        public Node<T> Right { get; set; }

        public T Value { get; set; }
    }
}

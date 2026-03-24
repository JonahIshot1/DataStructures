using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Text;

namespace SkipList
{

    public class Node<T> where T : IComparable<T>
    {
        public T Value; // Value of the node
        public Node<T>? Next; // Rightward connection
        public Node<T>? Down; // Downward connection

        public int Height { get; } // Vertical height of the node

        public Node(T value, int H) { Value = value; Height = H; } // Fill out constructors
        public Node(T value, Node<T> down) { Value = value; Down = down; }

    }

}

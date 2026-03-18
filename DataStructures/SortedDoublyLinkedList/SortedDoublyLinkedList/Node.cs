using System;
using System.Collections.Generic;
using System.Text;

namespace SortedDoublyLinkedList
{
    public class Node<T> where T : IComparable<T>
    {
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; } // the only change

        public LList<T> parent;
        public T Value { get; set; }

        public Node(T value, LList<T> parent)
        {
            Value = value;
            Next = null;
            Previous = null;
            this.parent = parent;
        }
    }
}

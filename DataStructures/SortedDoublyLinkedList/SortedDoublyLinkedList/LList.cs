using System;
using System.Collections.Generic;
using System.Text;

namespace SortedDoublyLinkedList
{
    public class LList<T> where T : IComparable<T>
    {
        Node<T> Tail;
        Node<T> sentinal;
        public LList()
        {
            sentinal = new Node<T>(default,this);
        }
        public Node<T> getSent()
        {
            return sentinal;
        }

        public void IN(T t)
        {
            Node<T> pointer = sentinal;
            while (pointer.Next != null&& pointer.Next.Value.CompareTo(t)<0)
            {
                pointer = pointer.Next;
            }
            
            Node<T> temp = new Node<T> (t,this);
            if (pointer.Next == null) Tail = temp;
            temp.Next = pointer.Next;
            pointer.Next = temp;
            
        }


        public bool remove(T val)
        {
            Node<T> pointer = sentinal;
            while(pointer.Next!=null&& !pointer.Next.Value.Equals( val))
            {
                pointer=pointer.Next;
            }
            if (pointer.Next == null) return false;
            if (pointer.Next.Equals(Tail)) { Tail = pointer; return true; }
            pointer.Next = pointer.Next.Next;
            return true;

        }
    }
}

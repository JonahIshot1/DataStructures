using System.Diagnostics;
using System.Text;

namespace linkedList
{
    class Node<T>
    {
        public T Value;
        public Node<T>? Next;

        public Node(T value) { Value = value; } // Implement the constructors
        public Node(T value, Node<T> next) { Value = value; Next = next; }
    }
    class LinkedList<T>
    {

        public Node<T>? Head { get; private set; }
        public Node<T>? Tail { get; private set; }
        public int Count { get; private set; }

        //Constructors & Functions

        public void AddFirst(T value)
        {
            Count++;
            if (Head == null)
            {
                Head = new Node<T>(value);
                Tail = Head;
            }
            else
            {
                Node<T> temp = new Node<T>(value, Head);
                Head = temp;


            }
        } //add a new head at the beginning of the list

        public void AddLast(T value) //add a new tail at the end of the list
        {
            Count++;

            Node<T> temp = Head;
            if (Head == null)
            {
                Head = new Node<T>(value);
                Tail = Head;
            }
            else
            {
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }

                temp.Next = new Node<T>(value);
                Tail = new Node<T>(value);
            }
        }


        public void AddBefore(Node<T> node, T value)
        {
            Count++;
            Node<T> temp = Head;
            if (node.Value.Equals(Head.Value))
            {
                AddFirst(value);
                return;
            }
            while (temp.Next != node)
            {
                temp = temp.Next;
            }
            temp.Next = new Node<T>(value, node);

        } //add a new node before any specified (and extant) node

        public void AddAfter(Node<T> node, T value)
        {

            Node<T> temp = Head;
            while (temp != node)
            {
                temp = temp.Next;
            }
            Count++;
            temp.Next = new Node<T>(value, temp.Next);
        } //add a new node after any specified (and extant) node

        public bool RemoveFirst()
        {
            if (Head == null) return false;
            Head = Head.Next;
            Count--;
            return true;
        } //remove the first node

        public bool RemoveLast()
        {
            Count--;

            Node<T> temp = Head;
            if (Head == null)
            {
                return false;
            }
            else
            {
                while (temp.Next.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = null;
                Tail = temp;
                
                return true;

            }

        } //remove the last node 

        public bool Remove(T value)
        {
            Node<T> temp = Head;
            while (!value.Equals(temp.Next.Value))
            {
                temp = temp.Next;
                if (temp == null)
                {
                    return false;
                }
            }
            temp.Next = temp.Next.Next;
            Count--;
            return true;

        } //find and remove a node containing the given value

        public void Clear()
        {
            if (Head != null)
            {
                Head.Next = null;
            }
            Head = null;
        } //delete every node in the linked list

        public Node<T> Search(T value)
        {
            Node<T> temp = Head;
            while (!value.Equals(temp.Value))
            {
                temp = temp.Next;
            }
            if (temp == null)
            {
                return null;
            }
            return temp;
        } //search for a given value and return a node that contains it, return null if none is found

        public bool Contains(T value)
        {
            return Search(value) != null;
        } //search for a given value and return if you found it.

        public bool Contains(Node<T> node)
        {
            Node<T> temp = Head;
            while (temp != node)
            {
                if (temp.Next == null) return false;
                temp = temp.Next;
            }
            return true;



        } //search for a given node and return if you found it.
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AddFirst(0);
            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);

            list.RemoveLast();
           

        }
    }
}

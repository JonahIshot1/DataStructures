using System.ComponentModel;
using System.Xml;
using System.Xml.Linq;

namespace Doubly_Linked_List
{
    internal class Program
    {
        class Node<T>
        {
            public Node<T> Next { get; set; }
            public Node<T> Previous { get; set; } // the only change

            public DoublyLinkedList<T> parent;
            public T Value { get; set; }

            public Node(T value, DoublyLinkedList<T> parent)
            {
                Value = value;
                Next = null;
                Previous = null;
                this.parent = parent;
            }
        }
        class DoublyLinkedList<T>
        {
            public int Count { get; private set; }

            public Node<T> Head { get; private set; }

            public Node<T> Tail
            {
                get; private set;
            }


            public void AddFirst(T value)
            {
                if (Head == null)
                {
                    Head = new Node<T>(value, this);
                    Head.Previous = Head;
                    Head.Next = Head;
                    Tail = Head;
                    Count++;
                    return;
                }

                Node<T> temp = Head;
                Head = new Node<T>(value, this);
                Head.Next = temp;
                Head.Previous = temp.Previous;
                temp.Previous = Head;
                Tail.Next = Head;

                Count++;
            }
            public void AddBefore(Node<T> node, T value)
            {
                Node<T> temp = Head;
                while (temp.Next != node)
                {
                    temp = temp.Next;
                }
                Node<T> neew = new Node<T>(value, this);
                neew.Next = temp.Next;
                neew.Previous = temp;
                temp.Next = neew;
                neew.Next.Previous = neew;
            }

            public void AddLast(T value)
            {
                Count++;
                if (Head == null)
                {
                    Head = new Node<T>(value, this);
                    Head.Previous = Head;
                    Head.Next = Head;
                    Tail = Head;
                    return;
                }
                Node<T> temp = Tail;
                Tail = new Node<T>(value, this);
                Head.Previous = Tail;
                Tail.Previous = temp;
                Tail.Next = Head;
                temp.Next = Tail;
            } //add a new tail at the end of the list

            public void AddAfter(Node<T> node, T value)
            {
                Node<T> temp = Head;
                while (temp != node)
                {
                    temp = temp.Next;
                }
                Node<T> neew = new Node<T>(value, this);
                neew.Next = temp.Next;
                neew.Previous = temp;
                temp.Next = neew;
                neew.Next.Previous = neew;
            } //add a new node after any specified (and extant) node

            public bool RemoveFirst()
            {
                if (Head == null) { return false; }
                if (Head.Next == Head)
                {
                    Clear();
                    return false;
                }
                Head.Next.Previous = Tail;
                Head = Head.Next;
                Tail.Next = Head;
                Count--;
                return true;

            } //remove the first node
            public bool RemoveLast()
            {
                if (Head == null) { return false; }
                if (Head == Tail)
                {
                    Clear();
                    return true;
                }
                Tail.Previous.Next = Head;
                Head.Previous = Tail.Previous;
                Tail = Tail.Previous;
                Count--;
                return true;
            } //remove the last node 

            public bool Remove(T value)
            {
                if(Head.Value.Equals(value))
                {
                    RemoveFirst();
                    return true;
                }
                if (Tail.Value.Equals(value))
                {
                    RemoveLast();
                    return true;
                }
                Node<T> temp = Head;
                while (!temp.Value.Equals(value))
                {
                    temp = temp.Next;
                    if (temp == null) { return false; }
                }
                temp.Previous.Next = temp.Next;
                temp.Next.Previous = temp.Previous;
                Count--;
                return true;

            } //find and remove a node containing the given value

            public void Clear()
            {
                Head = null;
                Tail = null;
                Count = 0;
            }

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
            }
            public bool Contains(Node<T> value)
            {
                return value.parent == this;
            } //Check if the given node belongs to this list in O(1) time
        }
        static void Main(string[] args)
        {
            DoublyLinkedList<int> doublyLinkedList = new DoublyLinkedList<int>();
            doublyLinkedList.AddFirst(1);
            doublyLinkedList.AddFirst(11);
            doublyLinkedList.AddFirst(87);
            doublyLinkedList.AddFirst(432);

            doublyLinkedList.Remove(432);


            //432,87,11,1,177,17731

            doublyLinkedList.AddLast(177);
            doublyLinkedList.AddLast(17731);

            doublyLinkedList.Remove(87);

            //doublyLinkedList.Clear();

            //if (doublyLinkedList.Contains(doublyLinkedList.Head))
            //{
            //    Console.WriteLine("bannans");
            //}



        }
    }
}

namespace Doubly_Linked_List
{
    internal class Program
    {
        class Node<T>
        {
            public Node<T> Next { get; set; }
            public Node<T> Previous { get; set; } // the only change

            public T Value { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = null;
                Previous = null;
            }
        }
        class DoublyLinkedList<T>
        {
            public int Count { get; private set; }

            public Node<T> Head { get; private set; }
            public Node<T> Tail { get; private set; }

            public void AddFirst(T value)
            {
                if (Head == null)
                {
                    Head = new Node<T>(value);
                    Head.Previous = Head;
                    Head.Next = Head;
                    Tail = Head;
                    Count++;
                    return;
                }

                Node<T> temp = new Node<T>(Head.Value);

                Tail = Head;
                temp.Next = Head.Next;

                Head.Value = value;
                temp.Previous = Head;
                Head.Next = temp;

                Count++;

            } //add a new head at the beginning of the list

            public void AddBefore(Node<T> node, T value) { } //add a new node before any specified (and extant) node
        }
        static void Main(string[] args)
        {
            DoublyLinkedList<int> doublyLinkedList = new DoublyLinkedList<int>();
            doublyLinkedList.AddFirst(1);
            doublyLinkedList.AddFirst(11);
        }
    }
}

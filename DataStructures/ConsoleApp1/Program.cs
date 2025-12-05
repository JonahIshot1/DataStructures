namespace ConsoleApp1
{
    internal class Program
    {
        public class Queue<T>
        {
            public int Count { get; private set; } // The amount of items in the Queue
            private LinkedList<T> data; // Backing for the Queue

            public Queue() 
            {
                data = new LinkedList<T>();
            } // Construct the Queue

            public void Enqueue(T value) 
            {
                data.AddLast(value);
            } // Add an item to the end of the Queue
            public T Dequeue() 
            {
                if (IsEmpty()) { throw new NotImplementedException(); }
                T First =data.First();
                data.RemoveFirst();
                return First;
            } // Remove and get the item at the front of the Queue
            public T Peek()
            {
                return data.First();
            } // Get the item at the front of the Queue


            // Optional Functions
            public bool IsEmpty() { return data.First == null; } // Returns if the Queue is empty
            public void Clear() { data.Clear(); } // Deletes all data in the Queue
        }
        static void Main(string[] args)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            q.Enqueue(5);
            q.Enqueue(6);
            q.Enqueue(7);

            for(int i =0; i <7; i ++)
            {
                Console.WriteLine(q.Dequeue());
                
            }
            bool b = q.IsEmpty();
        }
    }
}

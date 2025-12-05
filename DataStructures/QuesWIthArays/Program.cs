namespace QuesWIthArays
{
    internal class Program
    {
        public class Queue<T>
        {
            public int Count { get; private set; } // The amo items in the Queue
            private T[] data; // Backing for the Queue
            private int head; // The point to remove at
            private int tail; // The point to add at

            public Queue(int size)
            {
                head = 0;
                tail = 0;
                Count = 0;
                data = new T[size];
            } // Construct the Queue

            public void Enqueue(T value)
            {
                if (tail + 1 == data.Length)
                {
                    tail = 0;
                    Console.WriteLine("wrapped");
                }
                if (Count > 0 && tail <= head && tail + 1 >= head)
                {
                    Resize();
                }
                data[tail] = value;
                tail++;
                Count++;
            } // Add an item to the end of the Queue
            public T Dequeue()
            {
                T awnser = Peek();

                head++;
                if (head == data.Length) { head = 0; }
                Count--;


                return awnser;
            } // Remove and get the item at the front of the Queue
            public T Peek()
            {
                return data[head];
            } // Get the item at the front of the Queue

            private void Resize()
            {
                T[] temp = data;
                data = new T[temp.Length * 2];
                int curSpot = head;

                for (int i = 0; i + head != temp.Length; i++)
                {
                    data[i] = temp[head + i];
                    curSpot = i;
                }
                curSpot--;
                for (int i = 0; i < tail; i++)
                {
                    data[curSpot + i] = temp[i];
                }

                head = 0;
                tail = 2*temp.Length-1;


            } // Resize and re-index the data 

            // Optional Functions
            public bool IsEmpty() { return tail == head; } // Returns if the Queue is empty
            public void Clear()
            {
                head = 0;
                tail = 0;
                data = new T[10];
            } // Deletes all data in the Queue
        }
        static void Main(string[] args)
        {
            Queue<int> q = new Queue<int>(10);
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            int l = q.Dequeue();
            int j = q.Dequeue();
            int h = q.Dequeue();
            q.Enqueue(5);
            q.Enqueue(6);
            q.Enqueue(7);
            q.Enqueue(8);
            q.Enqueue(9);
            q.Enqueue(10);
            q.Enqueue(11);
            q.Enqueue(12);
            q.Enqueue(13);

            q.Enqueue(6);
            q.Enqueue(62);
            q.Enqueue(193);
            int p = q.Dequeue();
            int k = q.Dequeue();
            int o = q.Dequeue();
        }
    }
}

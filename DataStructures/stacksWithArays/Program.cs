using System.Collections;
using System.Globalization;
using System.Security.Cryptography;

namespace stacksWithArays
{
    internal class Program
    {
        public class Stack<T>
        {
            public int Count { get; private set; }
            private T[] data;

            public Stack(int capacity = 10) 
            {  
                data = new T[capacity];
                Count =0;
            }
            public void Push(T value)
            {
                if (data.Length == Count)
                {
                    Resize(data.Length * 2);
                }
                Count++;

                data[Count] = value;
            }
            
            public T Pop() 
            {
                if (IsEmpty()) { throw new uSuck(); }
                Count--;
                return data[Count+1];
            }
            public T Peek() 
            { 
            return data[Count];
            }
            private void Resize(int size) 
            {
                if (size < data.Length)
                {
                    return;
                }
                T[] temp = new T[size];
                for (int i = 0; i < data.Length; i++)
                {
                    temp[i] = data[i];
                }
                data = temp;
                
            }

            // Optional Functions
            public void Clear()
            {
                data = new T[data.Length];
                Count = 0;
            }
            public bool IsEmpty()
            {
                return Count == 0;
            }
        }
        static void Main(string[] args)
        {
            Stack<int> stacky = new Stack<int> ();
            stacky.Push(731);
            stacky.Push(1);
            stacky.Push(103);
            stacky.Push(9131);
            stacky.Push(1034);
            stacky.Clear();
            stacky.Push(803);
            stacky.Push(4);
            stacky.Push(11);
            int p = stacky.Peek();
            int count = stacky.Count;
            for (int i = 0; i <count; i++)
            {
                Console.Write(stacky.Pop());
                Console.Write(" , ");
                Console.WriteLine(stacky.Count);
            }
            Console.WriteLine(stacky.Count);
        }
    }
    class uSuck : Exception
    { }

}

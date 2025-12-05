namespace LinkedListBackStacks
{
    internal class Program
    {
        public class Stack<T>
        {
            public int Count { get; private set; }
            private LinkedList<T> data;

            public Stack() 
            {
                data = new LinkedList<T>();
                Count = 0;
            }
            public void Push(T value)
            { 
                data.AddFirst(value);
            }
            public T Pop() 
            {
                if (data.First != null)
                {
                    T first = data.First();
                    data.RemoveFirst();
                    return first;
                }
                throw new SkillIssueException();
            }
            public T Peek() 
            {
               return data.First();
            }

            // Optional Functions
            public void Clear() 
            {
                data.Clear();
            }

            public bool IsEmpty()
            {
                return data.First == null;
            }
        }
        static void Main(string[] args)
        {
            Stack<int> stacky= new Stack<int>();
            stacky.Pop();
        }
    }

    public class SkillIssueException : Exception
    { 
    
    }
}

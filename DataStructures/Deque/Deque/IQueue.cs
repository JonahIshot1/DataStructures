using System;
using System.Collections.Generic;
using System.Text;

namespace Deque
{
    public interface IQueue<T>
    {
        public void Enqueue(T value);
        public T Dequeue();
        public T Peek();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Deque
{
    public interface IStack<T>
    {
        public void Push(T value);
        public T Pop();
        public T Peek();
    }
}

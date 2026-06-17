using System;
using System.Collections.Generic;
using System.Text;

namespace Deque
{
    public interface IDeque<T>
    {
        public void PushFront(T value);
        public T PopFront();
        public T PeekFront();

        public void PushBack(T value);
        public T PopBack();
        public T PeekBack();
    }
}

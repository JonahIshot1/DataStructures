using System;
using System.Collections.Generic;
using System.Text;

namespace Deque
{
    public class Deque<T> : IDeque<T>, IStack<T>, IQueue<T>
    {
        LinkedList<T> list;
        public Deque()
        {
            list = new();
        }
        public T Dequeue()
        {
            var temp = list.First;
            list.RemoveFirst();
            return temp.Value;
        }

        public void Enqueue(T value)
        {
            list.AddLast(value);
        }
        public T Peek()
        {
            return list.First();
        }
        T IQueue<T>.Peek()
        {
            return list.First();
        }

        public T PeekBack()
        {
            return list.Last();
        }

        public T PeekFront()
        {
            return list.First();
        }

        T IStack<T>.Pop()
        {

            var temp = list.First;
            list.RemoveFirst();
            return temp.Value;
        }

        public T PopBack()
        {
            var temp = list.Last;
            list.RemoveLast();
            return temp.Value;
        }

        public T PopFront()
        {
            var temp = list.First;
            list.RemoveFirst();
            return temp.Value;
        }

        void IStack<T>.Push(T value)
        {
            list.AddFirst(value);
        }

        public void PushBack(T value)
        {
            list.AddLast(value);
        }

        public void PushFront(T value)
        {
           list.AddFirst(value);
        }
    }
}

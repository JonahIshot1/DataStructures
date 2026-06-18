using Deque;

namespace dequeTest
{
    public class UnitTest1
    {
        [Fact]
        public void DequeTest()
        {
            Deque<int> q = new Deque<int>();
            for (int i = 0; i < 10; i++)
            {
                q.Enqueue(i);
            }

            Assert.True(q.Dequeue()==0);
            q.PushFront(0);
            Assert.True(q.list.Count == 10);
            Assert.True(q.list.First.Value == q.Peek());
            Assert.True(q.list.Last.Value == q.PeekBack());
            Assert.True(q.list.First.Value == q.PeekFront());
            Assert.True(q.list.First.Value == q.PopFront());
            q.PushFront(0);
            Assert.True(q.list.Last.Value == q.PopBack());
            q.Enqueue(9);
            





        }
    }
}

using SortedDoublyLinkedList;


namespace SortedDoublyLinkedListTEst
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Random rand = new Random();
            LList<int> list = new LList<int>();
            for(int i= 0;i <1000;i++)
            {
                list.IN(rand.Next(1,1000));
            }
            Node<int> cur = list.getSent().Next;
            for (int i =0; i < 99;i++)
            {
                Assert.True(cur.Value.CompareTo(cur.Next.Value)<=0);
                cur = cur.Next;
            }
        }
    }
}
